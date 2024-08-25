using MediatR;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Tags;

public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, GetTagResponse>
{
    private readonly ITagRepository<Tag> _repository;

    public GetTagByIdHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<GetTagResponse> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
