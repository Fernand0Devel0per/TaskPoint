using MediatR;
using TaskPoint.Domain.Tools.Enums;
using TaskStatus = TaskPoint.Domain.Tools.Enums.TaskStatus;

namespace TaskPoint.Application.Commands.Request.Task;

public class UpdateTaskCommand : IRequest<bool>
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskStatus Status { get; set; }
}
