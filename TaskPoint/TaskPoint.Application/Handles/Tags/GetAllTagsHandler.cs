using MediatR;
using TaskPoint.Application.Commands.Request.Tags;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;
namespace TaskPoint.Application.Handles.Tags;

public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, GetAllTagsResponse>
{
    private readonly ITagRepository<Tag> _repository;

    public GetAllTagsHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllTagsResponse> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
