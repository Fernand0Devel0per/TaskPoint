using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Application.Mapping.Comments;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
{
    private readonly ICommentRepository<Comment> _repository;

    public UpdateCommentHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.FindByIdAsync(request.CommentId);
        if (comment is null)
        {
            return new UpdateCommentResponse { Success = false, Message = "Comment not found." };
        }

        var existingComment = await _repository.FindByIdAsync(request.CommentId);
        if (existingComment is not null && existingComment.CommentId != request.CommentId)
        {
            return new UpdateCommentResponse { Success = false, Message = "A comment with this content already exists." };
        }

        try
        {
            request.UpdateEntity(comment);
            await _repository.UpdateAsync(comment);
            return new UpdateCommentResponse { Success = true, Message = "Comment updated successfully." };
        }
        catch (Exception ex)
        {
            return new UpdateCommentResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }
}
