using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Application.Mapping.Projects;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, UpdateProjectResponse>
{
    private readonly IProjectRepository<Project> _repository;

    public UpdateProjectHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateProjectResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.FindByIdAsync(request.ProjectId);
        if (project is null)
        {
            return new UpdateProjectResponse { Success = false, Message = "Project not found." };
        }

        var existingProject = await _repository.FindByIdAsync(request.ProjectId);
        if (existingProject is not null && existingProject.ProjectId != request.ProjectId)
        {
            return new UpdateProjectResponse { Success = false, Message = "A project with this name already exists." };
        }

        try
        {
            request.UpdateEntity(project);
            await _repository.UpdateAsync(project);
            return new UpdateProjectResponse { Success = true, Message = "Project updated successfully." };
        }
        catch (Exception ex)
        {
            return new UpdateProjectResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
