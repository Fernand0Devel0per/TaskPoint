using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository<Comment>
{
    public CommentRepository(TaskPointDbContext context) : base(context)
    {
    }

   
}
