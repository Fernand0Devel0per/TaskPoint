namespace TaskPoint.Application.Commands.Response.Comment;

public record GetManyCommentsResponse : BaseResponse
{
    public IList<GetCommentResponse> GetCommentsResponse { get; set; }

    public GetManyCommentsResponse()
    {
        GetCommentsResponse = new List<GetCommentResponse>();
    }
}
