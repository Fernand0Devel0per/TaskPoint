using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Application.Mapping.Projects;
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
        try
        {
            var project = request.ToEntity();
            await _repository.AddAsync(project);
            return new CreateProjectResponse { Success = true, ProjectId = project.ProjectId, Message = "Project created successfully." };
        }
        catch (Exception ex)
        {
            return new CreateProjectResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
