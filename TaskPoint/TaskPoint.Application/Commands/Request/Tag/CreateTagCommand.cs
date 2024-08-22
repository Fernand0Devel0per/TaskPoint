using MediatR;
using TaskPoint.Application.Commands.Response.Tag;

namespace TaskPoint.Application.Commands.Request.Tag;

public class CreateTagCommand : IRequest<CreateTagResponse>
{
    public string Name { get; set; }
    public string Color { get; set; }
}
