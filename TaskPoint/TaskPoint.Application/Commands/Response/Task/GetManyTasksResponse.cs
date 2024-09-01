namespace TaskPoint.Application.Commands.Response.Task;

public record GetManyTasksResponse : BaseResponse
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public IList<GetTaskResponse> GetTasksResponse { get; set; }
    public GetManyTasksResponse()
    {
        GetTasksResponse  = new List<GetTaskResponse>();
    }
}
