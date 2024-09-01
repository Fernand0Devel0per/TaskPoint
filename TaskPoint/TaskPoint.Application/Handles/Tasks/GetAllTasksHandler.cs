﻿using MediatR;
using TaskPoint.Application.Commands.Request.Tags;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Domain.Model;
using TaskPoint.Persistence.Interface;
using Task = TaskPoint.Domain.Model.Task;
namespace TaskPoint.Application.Handles.Tasks;

public class GetAllTasksHandler : IRequestHandler<GetManyTasksQuery, GetManyTasksResponse>>
{
    private readonly ITaskRepository<Task> _repository;

    public GetAllTasksHandler(ITaskRepository<Task> repository)
    {
        _repository = repository;
    }

    public async Task<GetManyTasksResponse> Handle(GetManyTasksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
