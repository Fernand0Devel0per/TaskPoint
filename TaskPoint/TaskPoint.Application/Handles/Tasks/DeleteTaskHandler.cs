using MediatR;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Application.Handles.Tasks;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskResponse>
{
    private readonly ITaskRepository<Task> _repository;

    public DeleteTaskHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteTaskResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _repository.FindByIdAsync(request.TaskId);
        if (task is null)
        {
            return new DeleteTaskResponse { Success = false, Message = "Task not found." };
        }

        try
        {
            await _repository.DeleteAsync(task);
            return new DeleteTaskResponse { Success = true, Message = "Task deleted successfully." };
        }
        catch (Exception ex)
        {
            return new DeleteTaskResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
