using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, bool>
{
    private readonly IProjectRepository<Project> _repository;

    public UpdateProjectHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
