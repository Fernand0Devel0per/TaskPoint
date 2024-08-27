namespace TaskPoint.Application.Commands.Response.Task;

public class GetAllTasksResponse : ResponseBase
{
    public IList<GetTaskResponse> GetTasksResponse { get; set; }
    public GetAllTasksResponse()
    {
        GetTasksResponse  = new List<GetTaskResponse>();
    }
}
