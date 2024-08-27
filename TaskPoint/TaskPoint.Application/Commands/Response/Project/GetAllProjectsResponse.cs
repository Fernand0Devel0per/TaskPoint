namespace TaskPoint.Application.Commands.Response.Project;

public class GetAllProjectsResponse : ResponseBase
{
    public IList<GetProjectResponse> GetProjectsResponse { get; set; }
    public GetAllProjectsResponse()
    {
        GetProjectsResponse = new List<GetProjectResponse>();
    }
}
