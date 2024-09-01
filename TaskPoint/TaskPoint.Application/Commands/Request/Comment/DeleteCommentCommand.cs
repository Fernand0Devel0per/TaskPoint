using MediatR;
using TaskPoint.Application.Commands.Response.Comment;

namespace TaskPoint.Application.Commands.Request.Comment;

public record DeleteCommentCommand : IRequest<DeleteCommentResponse>
{
    public Guid CommentId { get; set; }
}
