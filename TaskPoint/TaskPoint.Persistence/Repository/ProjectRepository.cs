using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository<Project>
{
    public ProjectRepository(TaskPointDbContext context) : base(context)
    {
    }
}
