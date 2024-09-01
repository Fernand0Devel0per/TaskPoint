namespace TaskPoint.Application.Commands.Response.Tag;

public record GetManyTagsResponse : BaseResponse
{
    public IList<GetTagResponse> GetTasksResponse { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public GetManyTagsResponse()
    {
        GetTasksResponse = new List<GetTagResponse>();
    }
}
