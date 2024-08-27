using MediatR;
using TaskPoint.Application.Commands.Response.Task;

namespace TaskPoint.Application.Commands.Request.Task;

public class GetAllTasksQuery : IRequest<GetAllTasksResponse>
{
}
