using Actors.Application.Common.Exceptions;
using Actors.WebUI.Common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Actors.WebUI.Common.Middlewares;
/// <summary>
/// Handle http requests and Provides an HTTP response based on the exception type
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        object response = default!;
        var code = HttpStatusCode.InternalServerError;
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        };

        switch (exception)
        {
            case ActorsException ActorException:
                code = ActorException.StatusCode;
                response = new ErrorResponse
                {
                    Code = ActorException.StatusCode.ToString(),
                    Message = ActorException.Message,
                };
                break;

            case ValidationException ex:
                code = HttpStatusCode.BadRequest;
                response = new ErrorResponse
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Message = ex.Message,
                    Errors = ex.Errors
                };
                break;
            case KeyNotFoundException ex:
                code = HttpStatusCode.NotFound;
                response = new ErrorResponse
                {
                    Code = HttpStatusCode.NotFound.ToString(),
                    Message = ex.Message
                };
                break;
            case Exception ex:
                _logger.LogError(ex, ex.Message);
                response = new ErrorResponse
                {
                    Code = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Server error"
                };
                break;

            default:
                break;
        }

        var payload = JsonConvert.SerializeObject(response, settings);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(payload);
    }
}

public static class ErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}