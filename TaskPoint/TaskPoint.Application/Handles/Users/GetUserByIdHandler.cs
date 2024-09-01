using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Application.Mapping.Users;
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
        var user = await _repository.FindByIdAsync(request.UserId);
        if (user is null)
        {
            return new GetUserResponse { Success = false, Message = "User not found." };
        }

        

        return user.ToGetUserResponse() with { Success = true };;
    }
}
