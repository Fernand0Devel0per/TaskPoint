using MediatR;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskPoint.Application.Handles.Users;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUserRepository<User> _repository;

    public DeleteUserHandler(IUserRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        
        var user = await _repository.FindByIdAsync(request.UserId);
        if (user is null)
        {
            return new DeleteUserResponse { Success = false, Message = "User not found." };
        }

        try
        {
            await _repository.DeleteAsync(user);
            return new DeleteUserResponse { Success = true };
        }
        catch (Exception ex)
        {
            return new DeleteUserResponse
            {
                Success = false,
                Message =  "An error occurred while deleting the user." ,
                Errors = { ex.Message }
            };
 
         
        }
        
        
    }
}
