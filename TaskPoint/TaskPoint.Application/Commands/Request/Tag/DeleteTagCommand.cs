using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.Tag;

namespace TaskPoint.Application.Commands.Request.Tag;

public record DeleteTagCommand : IRequest<DeleteTagResponse>
{
    [Required]
    public Guid TagId { get; set; }
}
