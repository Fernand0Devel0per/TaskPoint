using Model = TaskPoint.Domain.Model;
namespace TaskPoint.Persistence.Interface;

public interface IUserRepository<User> : IBaseRepository<Model.User>
{
    Task<User> GetByEmailAsync(string email);
}
