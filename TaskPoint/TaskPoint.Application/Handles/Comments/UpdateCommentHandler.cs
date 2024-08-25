using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, bool>
{
    private readonly ICommentRepository<Comment> _repository;

    public UpdateCommentHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
