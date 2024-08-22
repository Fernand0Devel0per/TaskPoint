namespace TaskPoint.Application.Commands.Response.Task;

public class CreateTaskResponse
{
    public Guid TaskId { get; set; }

    public CreateTaskResponse(Guid taskId)
    {
        TaskId = taskId;
    }
}
