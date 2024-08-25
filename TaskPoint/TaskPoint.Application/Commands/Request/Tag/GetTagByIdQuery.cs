using MediatR;
using TaskPoint.Application.Commands.Response.Tag;

namespace TaskPoint.Application.Commands.Request.Tag;

public class GetTagByIdQuery : IRequest<GetTagResponse>
{
    public Guid TagId { get; set; }
}
