using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class GetAllCommentsHandler : IRequestHandler<GetManyCommentsQuery , GetManyCommentsResponse>
{
    private readonly ICommentRepository<Comment> _repository;

    public GetAllCommentsHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<GetManyCommentsResponse> Handle(GetManyCommentsQuery request, CancellationToken cancellationToken)
    {
       throw new NotImplementedException();
    }
}
