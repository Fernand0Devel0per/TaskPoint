using Microsoft.EntityFrameworkCore;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository<User>
{
    public UserRepository(TaskPointDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Set<User>()
                             .FirstOrDefaultAsync(u => u.Email == email);
    }

}
