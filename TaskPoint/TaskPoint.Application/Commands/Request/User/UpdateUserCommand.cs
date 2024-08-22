using MediatR;
using TaskPoint.Domain.Tools.Enums;

namespace TaskPoint.Application.Commands.Request.User;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public UserRole Role { get; set; }
}

