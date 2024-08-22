using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class TaskTagRepository : BaseRepository<TaskTag>, ITaskTagRepository<TaskTag>
{
    public TaskTagRepository(TaskPointDbContext context) : base(context)
    {
    }
}
