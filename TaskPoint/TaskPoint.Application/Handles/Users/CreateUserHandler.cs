using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Users;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserRepository<User> _repository;

    public CreateUserHandler(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
