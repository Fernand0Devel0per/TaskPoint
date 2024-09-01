namespace TaskPoint.Application.Commands.Response.Task;

public record CreateTaskResponse : BaseResponse
{
    public Guid TaskId { get; set; }


}
