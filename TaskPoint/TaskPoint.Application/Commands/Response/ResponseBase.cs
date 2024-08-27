namespace TaskPoint.Application.Commands.Response;

public class ResponseBase
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }

    public ResponseBase()
    {
        Errors = new List<string>();
    }
}
