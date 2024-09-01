using Model = TaskPoint.Domain.Model;
namespace TaskPoint.Persistence.Interface;

public interface IProjectRepository<Project> : IBaseRepository<Model.Project>
{
    Task<int> GetTotalProjectsCountAsync();
    Task<IList<Project>> FindManyPagedAsync(int pageNumber, int pageSize);
}
