using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Persistence.Repository;

public class TaskRepository : BaseRepository<Task>, ITaskTagRepository<Task>
{
    public TaskRepository(TaskPointDbContext context) : base(context)
    {
    }
}
