using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Users;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserRepository<User> _repository;

    public DeleteUserHandler(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
