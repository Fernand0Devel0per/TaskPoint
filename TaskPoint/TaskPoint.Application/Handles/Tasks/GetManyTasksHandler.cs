using MediatR;
using TaskPoint.Application.Commands.Request.Tags;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Application.Mapping.Tasks;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;
namespace TaskPoint.Application.Handles.Tasks;

public class GetManyTasksHandler : IRequestHandler<GetManyTasksQuery, GetManyTasksResponse>
{
    private readonly ITaskRepository<Task> _repository;

    public GetManyTasksHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<GetManyTasksResponse> Handle(GetManyTasksQuery request, CancellationToken cancellationToken)
    {
        var totalRecords = await _repository.GetTotalTasksCountAsync();
        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        var tasks = await _repository.FindManyPagedAsync(request.PageNumber, request.PageSize);
        var taskResponses = tasks.Select(task => task.ToGetTaskResponse()).ToList();

        return new GetManyTasksResponse
        {
            GetTasksResponse = taskResponses,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            Success = true,
            Message = taskResponses.Any() ? "Tasks retrieved successfully." : "No tasks found."
        };
    }
}
