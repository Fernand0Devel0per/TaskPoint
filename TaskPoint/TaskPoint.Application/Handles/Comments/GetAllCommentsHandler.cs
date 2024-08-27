using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class GetAllCommentsHandler : IRequestHandler<GetAllCommentsQuery , GetAllCommentsResponse>
{
    private readonly ICommentRepository<Comment> _repository;

    public GetAllCommentsHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllCommentsResponse> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
       throw new NotImplementedException();
    }
}
