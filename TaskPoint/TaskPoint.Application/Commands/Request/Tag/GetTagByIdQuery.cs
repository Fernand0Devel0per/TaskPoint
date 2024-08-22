using MediatR;
using TaskPoint.Application.Commands.Response.Tag;

namespace TaskPoint.Application.Commands.Request.Tag;

public class GetTagByIdQuery : IRequest<GetTagByIdResponse>
{
    public Guid TagId { get; set; }
}
