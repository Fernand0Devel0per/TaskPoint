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
    }

    private static async Task<IResult> CreateProject(IMediator mediator, [FromBody] CreateProjectCommand command)
    {
        try
        {
            var response = await mediator.Send(command);
            return Results.Created($"/api/projects/{response.ProjectId}", response);
        }
        catch (Exception)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> UpdateProject(IMediator mediator, [FromBody] UpdateProjectCommand command)
    {
        try
        {
            var success = await mediator.Send(command);
            return success ? Results.Ok() : Results.BadRequest();
        }
        catch (Exception)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> DeleteProject(IMediator mediator, [FromRoute] Guid projectId)
    {
        try
        {
            var success = await mediator.Send(new DeleteProjectCommand { ProjectId = projectId });
            return success ? Results.Ok() : Results.BadRequest();
        }
        catch (Exception)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> GetProjectById(IMediator mediator, [FromRoute] Guid projectId)
    {
        try
        {
            var response = await mediator.Send(new GetProjectByIdQuery { ProjectId = projectId });
            return response != null ? Results.Ok(response) : Results.NoContent();
        }
        catch (Exception)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
