using MediatR;
using TaskPoint.Application.Commands.Response.Project;

namespace TaskPoint.Application.Commands.Request.Project;

public record UpdateProjectCommand : IRequest<UpdateProjectResponse>
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
