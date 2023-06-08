using System.Net;

namespace Actors.Application.Common.Exceptions;
public class ActorsException : Exception
{
    public string Code { get; }
    public HttpStatusCode StatusCode { get; set; }
    public ActorsException()
    {
    }

    public ActorsException(string code)
    {
        Code = code;
    }

    public ActorsException(string message, HttpStatusCode httpStatusCode, params object[] args) : this(string.Empty, message, httpStatusCode, args)
    {
    }

    public ActorsException(string code, string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, params object[] args) : this(null!, code, message, args)
    {
        StatusCode = httpStatusCode;
    }

    public ActorsException(Exception innerException, string message, params object[] args)
        : this(innerException, string.Empty, message, args)
    {
    }

    public ActorsException(Exception innerException, string code, string message, params object[] args)
        : base(string.Format(message, args), innerException)
    {
        Code = code;
    }
}