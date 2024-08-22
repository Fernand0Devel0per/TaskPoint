namespace TaskPoint.Application.Commands.Response.User;

public class GetUserByIdResponse
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
}
