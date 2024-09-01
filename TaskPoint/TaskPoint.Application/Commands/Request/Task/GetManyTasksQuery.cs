using MediatR;
using TaskPoint.Application.Commands.Response.Task;

namespace TaskPoint.Application.Commands.Request.Task;

public record GetManyTasksQuery : IRequest<GetManyTasksResponse>
{
}
