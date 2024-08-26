namespace TaskPoint.Application.Commands.Response.User;

public class GetUserResponse
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
