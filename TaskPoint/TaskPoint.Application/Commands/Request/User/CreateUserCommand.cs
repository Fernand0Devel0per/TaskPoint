using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Application.Tools.Validators;

namespace TaskPoint.Application.Commands.Request.User;

public record CreateUserCommand : IRequest<CreateUserResponse>
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [PasswordComplexity(ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Password confirmation is required.")]
    [ComparePassword("Password", ErrorMessage = "The password confirmation does not match the password.")]
    public string PasswordConfirm { get; set; }

    public string Role { get; set; }
}
