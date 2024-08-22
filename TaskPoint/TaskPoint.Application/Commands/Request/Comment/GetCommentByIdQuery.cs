using MediatR;
using TaskPoint.Application.Commands.Response.Comment;

namespace TaskPoint.Application.Commands.Request.Comment;

public class GetCommentByIdQuery : IRequest<GetCommentByIdResponse>
{
    public Guid CommentId { get; set; }
}
