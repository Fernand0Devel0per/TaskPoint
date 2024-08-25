using MediatR;
using TaskPoint.Application.Commands.Response.User;

namespace TaskPoint.Application.Commands.Request.User;

public class GetUserByIdQuery : IRequest<GetUserResponse>
{
    public Guid UserId { get; set; }
}
