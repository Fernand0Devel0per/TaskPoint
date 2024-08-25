using MediatR;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Tags;

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, bool>
{
    private readonly ITagRepository<Tag> _repository;

    public UpdateTagHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
