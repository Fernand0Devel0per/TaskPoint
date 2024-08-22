using MediatR;

namespace TaskPoint.Application.Commands.Request.Comment;

public class UpdateCommentCommand : IRequest<bool>
{
    public Guid CommentId { get; set; }
    public string Content { get; set; }
}
