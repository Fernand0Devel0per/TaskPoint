using MediatR;
using TaskPoint.Application.Commands.Response.Task;

namespace TaskPoint.Application.Commands.Request.Task;

public class GetTaskByIdQuery : IRequest<GetTaskByIdResponse>
{
    public Guid TaskId { get; set; }
}
