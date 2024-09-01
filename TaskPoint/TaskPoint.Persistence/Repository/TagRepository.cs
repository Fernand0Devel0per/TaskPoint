using Microsoft.EntityFrameworkCore;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class TagRepository : BaseRepository<Tag>, ITagRepository<Tag>
{
    public TagRepository(TaskPointDbContext context) : base(context)
    {


    }

    public async Task<Tag> FindByNameAsync(string name)
    {
        return await _context.Tags
            .FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task<IEnumerable<Tag>> FindManyPagedAsync(int pageNumber, int pageSize)
    {
        var skip = (pageNumber - 1) * pageSize;
        return await _context.Tags
            .OrderBy(t => t.Name)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalTagsCountAsync()
    {
        return await _context.Tags.CountAsync();
    }
}
