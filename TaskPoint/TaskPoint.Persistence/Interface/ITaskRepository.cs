using Model = TaskPoint.Domain.Model;
namespace TaskPoint.Persistence.Interface;

public interface ITaskRepository<Task> : IBaseRepository<Model.Task>
{
    Task<int> GetTotalTasksCountAsync();
    Task<IList<Task>> FindManyPagedAsync(int pageNumber, int pageSize);
}
