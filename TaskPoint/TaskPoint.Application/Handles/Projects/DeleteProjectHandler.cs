using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, DeleteProjectResponse>
{
    private readonly IProjectRepository<Project> _repository;

    public DeleteProjectHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteProjectResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.FindByIdAsync(request.ProjectId);
        if (project is null)
        {
            return new DeleteProjectResponse { Success = false, Message = "Project not found." };
        }

        try
        {
            await _repository.DeleteAsync(project);
            return new DeleteProjectResponse { Success = true, Message = "Project deleted successfully." };
        }
        catch (Exception ex)
        {
            return new DeleteProjectResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
