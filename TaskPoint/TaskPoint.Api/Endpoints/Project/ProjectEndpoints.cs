using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;

namespace TaskPoint.Api.Endpoints.Project;

public static class ProjectEndpoints
{
    public static void ConfigureProjectEndpoints(this WebApplication app)
    {
        app.MapPost("/api/projects", CreateProject)
            .WithName("CreateProject")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
            .Accepts<CreateProjectCommand>("application/json")
            .Produces<CreateProjectResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapPut("/api/projects", UpdateProject)
            .WithName("UpdateProject")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
            .Accepts<UpdateProjectCommand>("application/json")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapDelete("/api/projects/{projectId:guid}", DeleteProject)
            .WithName("DeleteProject")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapGet("/api/projects/{projectId:guid}", GetProjectById)
            .WithName("GetProjectById")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Produces<GetProjectResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapGet("/api/projects", GetManyProjects)
            .WithName("GetManyProjects")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Produces<GetManyProjectsResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> CreateProject([FromBody] CreateProjectCommand command, IMediator mediator)
    {
        var response = await mediator.Send(command);

        if (response.Success)
        {
            return Results.Created($"/api/projects/{response.ProjectId}", response);
        }
        else if (response.Errors != null && response.Errors.Any())
        {
            return Results.BadRequest(response);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> UpdateProject([FromBody] UpdateProjectCommand command, IMediator mediator)
    {
        var response = await mediator.Send(command);

        if (response.Success)
        {
            return Results.Ok(response);
        }
        else if (response.Errors != null && response.Errors.Any())
        {
            return Results.BadRequest(response);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> DeleteProject(Guid projectId, IMediator mediator)
    {
        var response = await mediator.Send(new DeleteProjectCommand { ProjectId = projectId });

        if (response.Success)
        {
            return Results.Ok(response);
        }
        else if (response.Errors != null && response.Errors.Any())
        {
            return Results.BadRequest(response);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> GetProjectById(Guid projectId, IMediator mediator)
    {
        var response = await mediator.Send(new GetProjectByIdQuery { ProjectId = projectId });

        if (response != null)
        {
            return Results.Ok(response);
        }
        else
        {
            return Results.NoContent();
        }
    }

    private static async Task<IResult> GetManyProjects([FromQuery] int pageNumber, [FromQuery] int pageSize, IMediator mediator)
    {
        var query = new GetManyProjectsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var response = await mediator.Send(query);

        if (response.GetProjectsResponse.Any())
        {
            return Results.Ok(response);
        }
        else
        {
            return Results.NoContent();
        }
    }
}
