using MediatR;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Application.Mapping.Tasks;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Application.Handles.Tasks;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResponse>
{
    private readonly ITaskRepository<Task> _repository;

    public UpdateTaskHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateTaskResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _repository.FindByIdAsync(request.TaskId);
        if (task is null)
        {
            return new UpdateTaskResponse { Success = false, Message = "Task not found." };
        }

        var existingTask = await _repository.FindByIdAsync(request.TaskId);
        if (existingTask is not null && existingTask.TaskId != request.TaskId)
        {
            return new UpdateTaskResponse { Success = false, Message = "A task with this id already exists." };
        }

        try
        {
            request.UpdateEntity(task);
            await _repository.UpdateAsync(task);
            return new UpdateTaskResponse { Success = true, Message = "Task updated successfully." };
        }
        catch (Exception ex)
        {
            return new UpdateTaskResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
