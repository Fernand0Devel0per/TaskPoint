namespace TaskPoint.Application.Commands.Response.Task;

public record GetManyTasksResponse : BaseResponse
{
    public IList<GetTaskResponse> GetTasksResponse { get; set; }
    public GetManyTasksResponse()
    {
        GetTasksResponse  = new List<GetTaskResponse>();
    }
}
