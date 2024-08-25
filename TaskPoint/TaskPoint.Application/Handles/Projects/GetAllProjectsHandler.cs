using MediatR;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Projects;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<GetProjectResponse>>
{
    private readonly IProjectRepository<Project> _repository;

    public GetAllProjectsHandler(IProjectRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetProjectResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
