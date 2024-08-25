using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly ICommentRepository<Comment> _repository;

    public DeleteCommentHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
