using Model = TaskPoint.Domain.Model;

namespace TaskPoint.Persistence.Interface;

public interface ITagRepository<Tag> :IBaseRepository<Model.Tag>
{
    Task<Tag> FindByNameAsync(string name);
    Task<int> GetTotalTagsCountAsync();
    Task<IEnumerable<Tag>> FindManyPagedAsync(int pageNumber, int pageSize);
}
