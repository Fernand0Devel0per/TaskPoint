using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Application.Mapping.Projects;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class GetAllProjectsHandler : IRequestHandler<GetManyProjectsQuery, GetManyProjectsResponse>
{
    private readonly IProjectRepository<Project> _repository;

    public GetAllProjectsHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<GetManyProjectsResponse> Handle(GetManyProjectsQuery request, CancellationToken cancellationToken)
    {
        var totalRecords = await _repository.GetTotalProjectsCountAsync();
        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        var projects = await _repository.FindManyPagedAsync(request.PageNumber, request.PageSize);
        var projectResponses = projects.Select(project => project.ToGetProjectResponse()).ToList();

        return new GetManyProjectsResponse
        {
            GetProjectsResponse = projectResponses,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            Success = true,
            Message = projectResponses.Any() ? "Projects retrieved successfully." : "No projects found."
        };
    }
}
