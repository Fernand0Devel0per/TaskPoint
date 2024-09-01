using Microsoft.EntityFrameworkCore;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Persistence.Repository;

public class TaskRepository : BaseRepository<Task>, ITaskRepository<Task>
{
    public TaskRepository(TaskPointDbContext context) : base(context)
    {
    }

    public async Task<int> GetTotalTasksCountAsync()
    {
        return await _context.Tasks.CountAsync();
    }

    public async Task<IList<Task>> FindManyPagedAsync(int pageNumber, int pageSize)
    {
        return await _context.Tasks
                             .OrderBy(t => t.CreatedDate)
                             .Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

}
