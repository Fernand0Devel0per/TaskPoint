using MediatR;

namespace TaskPoint.Application.Commands.Request.Task;

public class DeleteTaskCommand : IRequest<bool>
{
    public Guid TaskId { get; set; }
}

