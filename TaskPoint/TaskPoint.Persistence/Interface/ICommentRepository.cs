
using Model = TaskPoint.Domain.Model;
namespace TaskPoint.Persistence.Interface;

public interface ICommentRepository<Comment> : IBaseRepository<Model.Comment> 
{
    Task<int> GetTotalCommentsCountAsync();
    Task<IList<Comment>> FindManyPagedAsync(int pageNumber, int pageSize);
}
