using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Data;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Persistence.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository<User>
{
    public UserRepository(TaskPointDbContext context) : base(context)
    {
    }

    
}
