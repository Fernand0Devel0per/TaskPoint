namespace TaskPoint.Application.Commands.Response;

public record BaseResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }

    public BaseResponse()
    {
        Errors = new List<string>();
    }
}
