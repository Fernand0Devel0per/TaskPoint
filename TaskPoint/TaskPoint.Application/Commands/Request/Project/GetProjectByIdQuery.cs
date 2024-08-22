﻿using MediatR;
using TaskPoint.Application.Commands.Response.Project;

namespace TaskPoint.Application.Commands.Request.Project;

public class GetProjectByIdQuery : IRequest<GetProjectResponse>
{
    public Guid ProjectId { get; set; }
}
