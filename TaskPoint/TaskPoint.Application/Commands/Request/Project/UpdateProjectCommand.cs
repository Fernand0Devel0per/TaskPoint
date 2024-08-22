using MediatR;

namespace TaskPoint.Application.Commands.Request.Project;

public class UpdateProjectCommand : IRequest<bool>
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
