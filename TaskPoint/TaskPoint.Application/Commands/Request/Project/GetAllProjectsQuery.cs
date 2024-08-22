using MediatR;
using TaskPoint.Application.Commands.Response.Project;

namespace TaskPoint.Application.Commands.Request.Project;

public class GetAllProjectsQuery : IRequest<IEnumerable<GetProjectResponse>>
{
}
