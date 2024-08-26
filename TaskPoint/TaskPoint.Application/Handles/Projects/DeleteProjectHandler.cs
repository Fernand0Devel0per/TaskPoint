using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, bool>
{
    private readonly IProjectRepository<Project> _repository;

    public DeleteProjectHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
