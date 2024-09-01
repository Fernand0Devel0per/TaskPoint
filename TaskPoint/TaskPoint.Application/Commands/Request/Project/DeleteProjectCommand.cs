using MediatR;

namespace TaskPoint.Application.Commands.Request.Project;

public record DeleteProjectCommand : IRequest<bool>
{
    public Guid ProjectId { get; set; }
}
