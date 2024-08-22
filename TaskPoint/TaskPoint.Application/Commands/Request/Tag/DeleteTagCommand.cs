using MediatR;

namespace TaskPoint.Application.Commands.Request.Tag;

public class DeleteTagCommand : IRequest<bool>
{
    public Guid TagId { get; set; }
}
