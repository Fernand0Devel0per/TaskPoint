using MediatR;
using TaskPoint.Application.Commands.Response.Comment;

namespace TaskPoint.Application.Commands.Request.Comment
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<GetCommentResponse>>
    {
    }
}
