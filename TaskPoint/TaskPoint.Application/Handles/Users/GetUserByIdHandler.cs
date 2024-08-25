using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Users;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserResponse>
{
    private readonly IUserRepository<User> _repository;

    public GetUserByIdHandler(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<GetUserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
