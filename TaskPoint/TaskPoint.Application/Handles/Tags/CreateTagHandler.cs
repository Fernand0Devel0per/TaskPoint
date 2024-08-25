using MediatR;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Tags;

public class CreateTagHandler : IRequestHandler<CreateTagCommand, CreateTagResponse>
{
    private readonly ITagRepository<Tag> _repository;

    public CreateTagHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<CreateTagResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
