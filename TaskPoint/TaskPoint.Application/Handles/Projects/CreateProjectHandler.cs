using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponse>
{
    private readonly IProjectRepository<Project> _repository;

    public CreateProjectHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<CreateProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
