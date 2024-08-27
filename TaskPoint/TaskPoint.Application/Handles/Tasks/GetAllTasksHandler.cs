using MediatR;
using TaskPoint.Application.Commands.Request.Tags;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;
namespace TaskPoint.Application.Handles.Tasks;

public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, GetAllTasksResponse>>
{
    private readonly ITaskRepository<Task> _repository;

    public GetAllTasksHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllTasksResponse> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
