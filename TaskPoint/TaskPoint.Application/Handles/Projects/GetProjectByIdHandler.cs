using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Application.Mapping.Projects;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, GetProjectResponse>
{
    private readonly IProjectRepository<Project> _repository;

    public GetProjectByIdHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<GetProjectResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.FindByIdAsync(request.ProjectId);
        if (project is null)
        {
            return new GetProjectResponse { Success = false, Message = "Project not found." };
        }

        return project.ToGetProjectResponse() with { Success = true };
    }
}
