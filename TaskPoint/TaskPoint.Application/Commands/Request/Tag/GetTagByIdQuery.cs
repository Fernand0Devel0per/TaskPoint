using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.Tag;

namespace TaskPoint.Application.Commands.Request.Tag;

public record GetTagByIdQuery : IRequest<GetTagResponse>
{
    [Required]
    public Guid TagId { get; set; }
}
