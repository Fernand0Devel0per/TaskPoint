using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskPoint.Application.Commands.Response.Task;

namespace TaskPoint.Application.Commands.Request.Task;

public record GetManyTasksQuery : IRequest<GetManyTasksResponse>
{
    [Range(1, int.MaxValue, ErrorMessage = "Page number must be at least 1.")]
    public int PageNumber { get; init; } = 1;

    [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
    public int PageSize { get; init; } = 10;
}
