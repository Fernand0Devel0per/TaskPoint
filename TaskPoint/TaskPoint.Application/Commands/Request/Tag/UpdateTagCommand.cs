using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Tools.Validators;

namespace TaskPoint.Application.Commands.Request.Tag;

public record UpdateTagCommand : IRequest<UpdateTagResponse>
{
    public Guid TagId { get; set; }
    [MaxLength(30, ErrorMessage = "The name cannot be longer than 30 characters.")]
    public string Name { get; set; }
    
    [HexColor]
    public string Color { get; set; }
}
