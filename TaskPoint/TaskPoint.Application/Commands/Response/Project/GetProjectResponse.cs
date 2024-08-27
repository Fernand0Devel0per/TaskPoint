namespace TaskPoint.Application.Commands.Response.Project;

public class GetProjectResponse : ResponseBase
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }
}
