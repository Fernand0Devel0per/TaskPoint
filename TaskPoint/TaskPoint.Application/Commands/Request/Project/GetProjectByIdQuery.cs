using MediatR;
using TaskPoint.Application.Commands.Response.Project;

namespace TaskPoint.Application.Commands.Request.Project;

public record GetProjectByIdQuery : IRequest<GetProjectResponse>
{
    public Guid ProjectId { get; set; }
}
