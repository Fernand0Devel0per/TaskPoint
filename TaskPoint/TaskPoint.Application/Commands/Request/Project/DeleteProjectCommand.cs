using MediatR;

namespace TaskPoint.Application.Commands.Request.Project;

public class DeleteProjectCommand : IRequest<bool>
{
    public Guid ProjectId { get; set; }
}
