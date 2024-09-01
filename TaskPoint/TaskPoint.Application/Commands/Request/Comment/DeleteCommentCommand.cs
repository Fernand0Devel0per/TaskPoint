using MediatR;

namespace TaskPoint.Application.Commands.Request.Comment;

public record DeleteCommentCommand : IRequest<bool>
{
    public Guid CommentId { get; set; }
}
