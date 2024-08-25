using MediatR;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Tags;

public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, bool>
{
    private readonly ITagRepository<Tag> _repository;

    public DeleteTagHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
