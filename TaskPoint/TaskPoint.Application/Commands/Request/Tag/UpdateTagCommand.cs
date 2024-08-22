using MediatR;

namespace TaskPoint.Application.Commands.Request.Tag;

public class UpdateTagCommand : IRequest<bool>
{
    public Guid TagId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}
