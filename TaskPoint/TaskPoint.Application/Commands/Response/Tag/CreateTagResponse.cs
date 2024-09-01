namespace TaskPoint.Application.Commands.Response.Tag;

public record CreateTagResponse : BaseResponse
{
    public Guid TagId { get; set; }

}
