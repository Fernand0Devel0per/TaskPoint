using Microsoft.EntityFrameworkCore;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly TaskPointDbContext _context;

    protected BaseRepository(TaskPointDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        var rowsAffected = await _context.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<IEnumerable<T>> FindAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> FindByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

}
