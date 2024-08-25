using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, GetCommentResponse>
{
    private readonly ICommentRepository<Comment> _repository;

    public GetCommentByIdHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<GetCommentResponse> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
