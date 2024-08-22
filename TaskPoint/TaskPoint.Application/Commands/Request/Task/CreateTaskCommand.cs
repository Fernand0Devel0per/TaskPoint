using MediatR;
using TaskPoint.Domain.Tools.Enums;
using TaskPoint.Application.Commands.Response.Task;

namespace TaskPoint.Application.Commands.Request.Task;

public class CreateTaskCommand : IRequest<CreateTaskResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; }
}

