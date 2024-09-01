using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Application.Mapping.Comments;
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
        var comment = await _repository.FindByIdAsync(request.CommentId);
        if (comment is null)
        {
            return new GetCommentResponse { Success = false, Message = "Comment not found." };
        }

        return comment.ToGetCommentResponse() with { Success = true };
    }
}
