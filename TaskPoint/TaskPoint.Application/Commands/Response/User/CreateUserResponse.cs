namespace TaskPoint.Application.Commands.Response.User;

public class CreateUserResponse
{
    public Guid UserId { get; set; }

    public CreateUserResponse(Guid userId)
    {
        UserId = userId;
    }
}
