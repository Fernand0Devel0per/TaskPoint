using MediatR;
using TaskPoint.Application.Commands.Response.Project;

namespace TaskPoint.Application.Commands.Request.Project;

public record DeleteProjectCommand : IRequest<DeleteProjectResponse>
{
    public Guid ProjectId { get; set; }
}
