using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Application.Tools;
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

        var existingUser = await _repository.GetByEmailAsync(request.Email);
        if (existingUser is not null)
        {
            return new CreateUserResponse { Success = false, Message = "User with this email already exists." };
        }

        try
        {
            var user = request.MapTo<CreateUserCommand, User>();
            await _repository.AddAsync(user);
            return new CreateUserResponse { Success = true, Message = "User created successfully.", UserId = user.UserId };
        }
        catch (Exception ex)
        {
            var responde = new CreateUserResponse { Success = false, Message = "An internal error occurred while processing your request. Please contact support if the problem persists." };
            responde.Errors.Add(ex.Message);
            return responde;
        }
             
    }
}

