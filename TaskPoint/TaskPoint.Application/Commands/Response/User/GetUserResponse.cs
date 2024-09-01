namespace TaskPoint.Application.Commands.Response.User;

public record GetUserResponse : BaseResponse
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
