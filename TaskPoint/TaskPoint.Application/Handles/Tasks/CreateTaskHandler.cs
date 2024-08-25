using MediatR;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
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
        throw new NotImplementedException();
    }
}
