using MediatR;
using TaskPoint.Application.Commands.Response.Task;

namespace TaskPoint.Application.Commands.Request.Task;

public record GetTaskByIdQuery : IRequest<GetTaskResponse>
{
    public Guid TaskId { get; set; }
}
