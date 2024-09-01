using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Application.Mapping.Comments;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
{
    private readonly ICommentRepository<Comment> _repository;

    public CreateCommentHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var comment = request.ToEntity();
            await _repository.AddAsync(comment);
            return new CreateCommentResponse { Success = true, CommentId = comment.CommentId, Message = "Comment created successfully." };
        }
        catch (Exception ex)
        {
            return new CreateCommentResponse
            {
                Success = false,
                Message = "An internal error occurred while processing your request. Please contact support if the problem persists.",
                Errors = { ex.Message }
            };
        }
    }

   
}
