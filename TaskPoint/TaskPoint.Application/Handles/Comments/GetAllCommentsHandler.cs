using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class GetAllCommentsHandler : IRequestHandler<GetAllCommentsQuery ,IEnumerable<GetCommentResponse>>
{
    private readonly ICommentRepository<Comment> _repository;

    public GetAllCommentsHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetCommentResponse>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
       //TODO
       throw new NotImplementedException();
    }
}
