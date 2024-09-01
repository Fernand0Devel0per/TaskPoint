using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Tools.Validators;

namespace TaskPoint.Application.Commands.Request.Tag;

public record CreateTagCommand : IRequest<CreateTagResponse>
{
    [Required(ErrorMessage = "The name field is required.")]
    [MaxLength(30, ErrorMessage = "The name cannot be longer than 30 characters.")]
    [NoSpecialCharacters]
    public string Name { get; set; }

    [Required(ErrorMessage = "The color field is required.")]
    [HexColor]
    public string Color { get; set; }
}
