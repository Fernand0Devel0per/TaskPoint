using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserRepository<User> _repository;

    public UpdateUserHandler(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
