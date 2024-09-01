using MediatR;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Mapping.Comments;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;

namespace TaskPoint.Application.Handles.Comments;

public class GetManyCommentsHandler : IRequestHandler<GetManyCommentsQuery , GetManyCommentsResponse>
{
    private readonly ICommentRepository<Comment> _repository;

    public GetManyCommentsHandler(ICommentRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task<GetManyCommentsResponse> Handle(GetManyCommentsQuery request, CancellationToken cancellationToken)
    {
        var totalRecords = await _repository.GetTotalCommentsCountAsync();
        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        var comments = await _repository.FindManyPagedAsync(request.PageNumber, request.PageSize);
        var commentResponses = comments.Select(comment => comment.ToGetCommentResponse()).ToList();

        return new GetManyCommentsResponse
        {
            GetCommentsResponse = commentResponses,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            Success = true,
            Message = commentResponses.Any() ? "Comments retrieved successfully." : "No comments found."
        };
    }
}
