using Microsoft.EntityFrameworkCore;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository<Comment>
{
    public CommentRepository(TaskPointDbContext context) : base(context)
    {

    }

    public async Task<int> GetTotalCommentsCountAsync()
    {
        return await _context.Comments.CountAsync();
    }

    public async Task<IList<Comment>> FindManyPagedAsync(int pageNumber, int pageSize)
    {
        return await _context.Comments
                             .OrderBy(c => c.CreatedDate)
                             .Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

}
