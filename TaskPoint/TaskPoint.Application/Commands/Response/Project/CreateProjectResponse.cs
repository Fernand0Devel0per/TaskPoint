namespace TaskPoint.Application.Commands.Response.Project;

public record CreateProjectResponse : BaseResponse
{
    public Guid ProjectId { get; set; }

    public CreateProjectResponse(Guid projectId)
    {
        ProjectId = projectId;
    }
}
