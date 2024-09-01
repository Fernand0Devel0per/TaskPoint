using MediatR;
using TaskPoint.Application.Commands.Request.Tags;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Mapping.Tags;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;
namespace TaskPoint.Application.Handles.Tags;

public class GetManyTagsHandler : IRequestHandler<GetManyTagsQuery, GetManyTagsResponse>
{
    private readonly ITagRepository<Tag> _repository;

    public GetManyTagsHandler(ITagRepository<Tag> repository)
    {
        _repository = repository;
    }

    public async Task<GetManyTagsResponse> Handle(GetManyTagsQuery request, CancellationToken cancellationToken)
    {
        var totalRecords = await _repository.GetTotalTagsCountAsync();
        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        var tags = await _repository.FindManyPagedAsync(request.PageNumber, request.PageSize);
        var tagResponses = tags.Select(tag => tag.ToGetTagResponse()).ToList();

        return new GetManyTagsResponse
        {
            GetTasksResponse = tagResponses,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            Success = true,
            Message = tagResponses.Any() ? "Tags retrieved successfully." : "No tags found."
        };
    }
}
