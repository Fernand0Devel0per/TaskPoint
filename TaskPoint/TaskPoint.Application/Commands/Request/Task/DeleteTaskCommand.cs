using MediatR;

namespace TaskPoint.Application.Commands.Request.Task;

public record DeleteTaskCommand : IRequest<bool>
{
    public Guid TaskId { get; set; }
}

