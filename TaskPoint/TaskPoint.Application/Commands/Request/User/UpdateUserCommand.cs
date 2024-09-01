using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Domain.Tools.Enums;

namespace TaskPoint.Application.Commands.Request.User;

public record UpdateUserCommand : IRequest<UpdateUserResponse>
{
    [Required]
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string Role { get; set; }
}

