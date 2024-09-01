using Microsoft.EntityFrameworkCore;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository<Project>
{
    public ProjectRepository(TaskPointDbContext context) : base(context)
    {
    }
    public async Task<int> GetTotalProjectsCountAsync()
    {
        return await _context.Projects.CountAsync();
    }

    public async Task<IList<Project>> FindManyPagedAsync(int pageNumber, int pageSize)
    {
        return await _context.Projects
                             .OrderBy(p => p.CreatedDate)
                             .Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }
}
