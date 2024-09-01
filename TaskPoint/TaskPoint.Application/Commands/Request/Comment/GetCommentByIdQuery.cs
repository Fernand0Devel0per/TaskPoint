using MediatR;
using TaskPoint.Application.Commands.Response.Comment;

namespace TaskPoint.Application.Commands.Request.Comment;

public record GetCommentByIdQuery : IRequest<GetCommentResponse>
{
    public Guid CommentId { get; set; }
}
