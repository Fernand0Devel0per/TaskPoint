using MediatR;
using TaskPoint.Application.Commands.Response.Comment;

namespace TaskPoint.Application.Commands.Request.Comment;

public record UpdateCommentCommand : IRequest<UpdateCommentResponse>
{
    public Guid CommentId { get; set; }
    public string Content { get; set; }
}
