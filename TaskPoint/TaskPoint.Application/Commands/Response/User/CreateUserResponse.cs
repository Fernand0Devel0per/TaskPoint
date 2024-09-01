namespace TaskPoint.Application.Commands.Response.User;

public record CreateUserResponse : BaseResponse
{
    public Guid UserId { get; set; }
}
