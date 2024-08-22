using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class TagRepository : BaseRepository<Tag>, ITagRepository<Tag>
{
    public TagRepository(TaskPointDbContext context) : base(context)
    {
    }
}
