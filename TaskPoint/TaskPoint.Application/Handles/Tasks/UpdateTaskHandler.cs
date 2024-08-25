using MediatR;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Application.Handles.Tasks;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, bool>
{
    private readonly ITaskRepository<Task> _repository;

    public UpdateTaskHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
