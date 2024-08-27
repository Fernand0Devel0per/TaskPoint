namespace TaskPoint.Application.Commands.Response.Tag;

public class CreateTagResponse : ResponseBase
{
    public Guid TagId { get; set; }

    public CreateTagResponse(Guid tagId)
    {
        TagId = tagId;
    }
}
