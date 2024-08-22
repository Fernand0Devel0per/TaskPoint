namespace TaskPoint.Persistence.Interface;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<IEnumerable<T>> FindAllAsync();
    Task<T> FindByIdAsync(Guid id);
}
