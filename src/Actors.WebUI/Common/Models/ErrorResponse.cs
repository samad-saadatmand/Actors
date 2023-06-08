namespace Actors.WebUI.Common.Models;
public class ErrorResponse
{
    public required string Code { get; set; }
    public string? Message { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }
}
