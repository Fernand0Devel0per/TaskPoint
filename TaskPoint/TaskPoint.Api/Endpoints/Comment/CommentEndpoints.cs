using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;

namespace TaskPoint.Api.Endpoints.Comment;

public static class CommentEndpoints
{
    public static void ConfigureCommentEndpoints(this WebApplication app)
    {
        app.MapPost("/api/comments", CreateComment)
            .WithName("CreateComment")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Accepts<CreateCommentCommand>("application/json")
            .Produces<CreateCommentResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapPut("/api/comments", UpdateComment)
            .WithName("UpdateComment")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Accepts<UpdateCommentCommand>("application/json")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapDelete("/api/comments/{commentId:guid}", DeleteComment)
            .WithName("DeleteComment")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapGet("/api/comments/{commentId:guid}", GetCommentById)
            .WithName("GetCommentById")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Produces<GetCommentResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status500InternalServerError);

        app.MapGet("/api/comments", GetManyComments)
            .WithName("GetManyComments")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
            .Produces<GetManyCommentsResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> CreateComment([FromBody] CreateCommentCommand command, IMediator mediator)
    {
        var response = await mediator.Send(command);

        if (response.Success)
        {
            return Results.Created($"/api/comments/{response.CommentId}", response);
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

    private static async Task<IResult> DeleteComment(Guid commentId, IMediator mediator)
    {
        var response = await mediator.Send(new DeleteCommentCommand { CommentId = commentId });

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

    private static async Task<IResult> UpdateComment([FromBody] UpdateCommentCommand command, IMediator mediator)
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

    private static async Task<IResult> GetCommentById(IMediator mediator, [FromRoute] Guid commentId)
    {
        try
        {
            var response = await mediator.Send(new GetCommentByIdQuery { CommentId = commentId });
            return response != null ? Results.Ok(response) : Results.NoContent();
        }
        catch (Exception)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> GetManyComments([FromQuery] int pageNumber, [FromQuery] int pageSize, IMediator mediator)
    {
        var query = new GetManyCommentsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var response = await mediator.Send(query);

        if (response.GetCommentsResponse.Any())
        {
            return Results.Ok(response);
        }
        else
        {
            return Results.NoContent();
        }
    }
}
