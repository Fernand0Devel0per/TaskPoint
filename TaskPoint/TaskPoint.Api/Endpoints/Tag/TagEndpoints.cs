﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Response.Tag;

namespace TaskPoint.Api.Endpoints.Tag;

public static class TagEndpoints
{
    public static void ConfigureTagEndpoints(this WebApplication app)
    {
        app.MapPost("/api/tags", CreateTag)
            .WithName("CreateTag")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
            .Accepts<CreateTagCommand>("application/json")
            .Produces<CreateTagResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapPut("/api/tags", UpdateTag)
            .WithName("UpdateTag")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
            .Accepts<UpdateTagCommand>("application/json")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapDelete("/api/tags/{tagId:guid}", DeleteTag)
            .WithName("DeleteTag")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapGet("/api/tags/{tagId:guid}", GetTagById)
            .WithName("GetTagById")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Produces<GetTagResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> CreateTag([FromBody] CreateTagCommand command, IMediator mediator)
    {
        var response = await mediator.Send(command);

        if (response.Success)
        {
            return Results.Created($"/api/tags/{response.TagId}", response);
        }
        else if (!response.Success)
        {
            return Results.BadRequest(response.Message);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> UpdateTag([FromBody] UpdateTagCommand command, IMediator mediator)
    {
        var response = await mediator.Send(command);

        if (response.Success)
        {
            return Results.Ok(response);
        }
        else if (!response.Success)
        {
            return Results.BadRequest(response.Message);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> DeleteTag(Guid tagId, IMediator mediator)
    {
        var response = await mediator.Send(new DeleteTagCommand { TagId = tagId });

        if (response.Success)
        {
            return Results.Ok(response);
        }
        else if (!response.Success)
        {
            return Results.BadRequest(response.Message);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    private static async Task<IResult> GetTagById(IMediator mediator, [FromRoute] Guid tagId)
    {
        try
        {
            var response = await mediator.Send(new GetTagByIdQuery { TagId = tagId });
            return response != null ? Results.Ok(response) : Results.NoContent();
        }
        catch (Exception)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
