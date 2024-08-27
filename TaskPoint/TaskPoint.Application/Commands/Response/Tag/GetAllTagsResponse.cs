namespace TaskPoint.Application.Commands.Response.Tag;

public class GetAllTagsResponse : ResponseBase
{
    public IList<GetTagResponse> GetTasksResponse { get; set; }
    public GetAllTagsResponse()
    {
        GetTasksResponse = new List<GetTagResponse>();
    }
}
