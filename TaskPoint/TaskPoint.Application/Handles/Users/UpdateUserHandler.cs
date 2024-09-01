using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Application.Mapping.Users;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUserRepository<User> _repository;

    public UpdateUserHandler(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.FindByIdAsync(request.UserId);
        if (user is null)
        {
            return new UpdateUserResponse { Success = false, Message = "User not found." };
        }

        try
        {
            
            request.UpdateEntity(user);

            await _repository.UpdateAsync(user);
            return new UpdateUserResponse { Success = true };
        }
        catch (Exception ex)
        {
            return new UpdateUserResponse {
                Success = false, 
                Message = "An error occurred while updating the user.",
                Errors = { ex.Message  } 
            };
        }
    }
}
