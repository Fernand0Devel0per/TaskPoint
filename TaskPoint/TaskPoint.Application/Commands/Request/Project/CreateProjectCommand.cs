using MediatR;
using TaskPoint.Application.Commands.Response.Project;

namespace TaskPoint.Application.Commands.Request.Project;

public class CreateProjectCommand : IRequest<CreateProjectResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

