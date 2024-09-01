namespace TaskPoint.Application.Commands.Response.Comment;

public record GetManyCommentsResponse : BaseResponse
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public IList<GetCommentResponse> GetCommentsResponse { get; set; }

    public GetManyCommentsResponse()
    {
        GetCommentsResponse = new List<GetCommentResponse>();
    }
}
