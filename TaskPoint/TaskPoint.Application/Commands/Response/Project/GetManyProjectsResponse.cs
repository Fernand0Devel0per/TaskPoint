namespace TaskPoint.Application.Commands.Response.Project;

public record GetManyProjectsResponse : BaseResponse
{
    public IList<GetProjectResponse> GetProjectsResponse { get; set; }
    public GetManyProjectsResponse()
    {
        GetProjectsResponse = new List<GetProjectResponse>();
    }
}
