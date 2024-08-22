using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
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
        //TO DO
        throw new NotImplementedException();
    }
}
