using MediatR;
using TaskPoint.Application.Commands.Response.Tag;

namespace TaskPoint.Application.Commands.Request.Tags;

public class GetAllTagsQuery : IRequest<GetAllTagsResponse>
{
}
