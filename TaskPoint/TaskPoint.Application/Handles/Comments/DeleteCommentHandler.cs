using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentResponse>
{
    private readonly ICommentRepository<Comment> _repository;

    public DeleteCommentHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteCommentResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.FindByIdAsync(request.CommentId);
        if (comment is null)
        {
            return new DeleteCommentResponse { Success = false, Message = "Comment not found." };
        }

        try
        {
            await _repository.DeleteAsync(comment);
            return new DeleteCommentResponse { Success = true, Message = "Comment deleted successfully." };
        }
        catch (Exception ex)
        {
            return new DeleteCommentResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
