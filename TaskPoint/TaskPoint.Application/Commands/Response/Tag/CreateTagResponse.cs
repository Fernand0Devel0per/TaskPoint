namespace TaskPoint.Application.Commands.Response.Tag;

public class CreateTagResponse
{
    public Guid TagId { get; set; }

    public CreateTagResponse(Guid tagId)
    {
        TagId = tagId;
    }
}
