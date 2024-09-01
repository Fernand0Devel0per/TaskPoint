using MediatR;
using TaskPoint.Application.Commands.Response.Comment;

namespace TaskPoint.Application.Commands.Request.Comment;

public record CreateCommentCommand : IRequest<CreateCommentResponse>
{
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
}
