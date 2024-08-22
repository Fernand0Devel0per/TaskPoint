namespace TaskPoint.Application.Commands.Response.Tag;

public class GetTagByIdResponse
{
    public Guid TagId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}
