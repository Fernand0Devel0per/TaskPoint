using MediatR;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Application.Mapping.Tasks;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;
namespace TaskPoint.Application.Handles.Tasks;

public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, GetTaskResponse>
{
    private readonly ITaskRepository<Task> _repository;

    public GetTaskByIdHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<GetTaskResponse> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _repository.FindByIdAsync(request.TaskId);
        if (task is null)
        {
            return new GetTaskResponse { Success = false, Message = "Task not found." };
        }

        return task.ToGetTaskResponse() with { Success = true };
    }
}
