using MediatR;

namespace TaskPoint.Application.Commands.Request.Comment;

public record UpdateCommentCommand : IRequest<bool>
{
    public Guid CommentId { get; set; }
    public string Content { get; set; }
}
