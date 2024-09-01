using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.User;

namespace TaskPoint.Application.Commands.Request.User;

public record GetUserByIdQuery : IRequest<GetUserResponse>
{
    [Required]
    public Guid UserId { get; set; }
}
