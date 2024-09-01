namespace TaskPoint.Application.Commands.Response.Task;

public record GetTaskResponse : BaseResponse
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime DueDate { get; set; }
    public Guid UserId { get; set; }
}
