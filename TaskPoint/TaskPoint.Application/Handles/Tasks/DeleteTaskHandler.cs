using MediatR;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Application.Handles.Tasks;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ITaskRepository<Task> _repository;

    public DeleteTaskHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
