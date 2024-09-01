using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
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
        throw new NotImplementedException();
    }
}
