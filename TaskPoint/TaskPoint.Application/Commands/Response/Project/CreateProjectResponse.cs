namespace TaskPoint.Application.Commands.Response.Project;

public class CreateProjectResponse
{
    public Guid ProjectId { get; set; }

    public CreateProjectResponse(Guid projectId)
    {
        ProjectId = projectId;
    }
}
