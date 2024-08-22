using MediatR;

namespace TaskPoint.Application.Commands.Request.Comment;

public class DeleteCommentCommand : IRequest<bool>
{
    public Guid CommentId { get; set; }
}
