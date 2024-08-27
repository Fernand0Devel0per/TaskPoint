namespace TaskPoint.Application.Commands.Response.Tag;

public class GetTagResponse : ResponseBase
{
    public Guid TagId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}
