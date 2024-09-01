using MediatR;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Application.Mapping.Tasks;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Application.Handles.Tasks;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponse>
{
    private readonly ITaskRepository<Task> _repository;

    public CreateTaskHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<CreateTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var task = request.ToEntity();
            await _repository.AddAsync(task);
            return new CreateTaskResponse { Success = true, TaskId = task.TaskId, Message = "Task created successfully." };
        }
        catch (Exception ex)
        {
            return new CreateTaskResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
