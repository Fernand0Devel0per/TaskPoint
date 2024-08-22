using MediatR;

namespace TaskPoint.Application.Commands.Request.User;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
}
