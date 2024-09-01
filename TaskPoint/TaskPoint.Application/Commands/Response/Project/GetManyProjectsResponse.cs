namespace TaskPoint.Application.Commands.Response.Project;

public record GetManyProjectsResponse : BaseResponse
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public IList<GetProjectResponse> GetProjectsResponse { get; set; }
    public GetManyProjectsResponse()
    {
        GetProjectsResponse = new List<GetProjectResponse>();
    }
}
