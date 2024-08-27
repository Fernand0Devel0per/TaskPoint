namespace TaskPoint.Application.Commands.Response.Comment;

public class GetAllCommentsResponse : ResponseBase
{
    public IList<GetCommentResponse> GetCommentsResponse { get; set; }

    public GetAllCommentsResponse()
    {
        GetCommentsResponse = new List<GetCommentResponse>();
    }
}
