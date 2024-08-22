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
    }

    private static async Task<IResult> CreateComment(IMediator mediator, [FromBody] CreateCommentCommand command)
    {
        try
        {
            var response = await mediator.Send(command);
            return Results.Created($"/api/comments/{response.CommentId}", response);
        }
        catch (Exception)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> UpdateComment(IMediator mediator, [FromBody] UpdateCommentCommand command)
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

    private static async Task<IResult> DeleteComment(IMediator mediator, [FromRoute] Guid commentId)
    {
        try
        {
            var success = await mediator.Send(new DeleteCommentCommand { CommentId = commentId });
            return success ? Results.Ok() : Results.BadRequest();
        }
        catch (Exception)
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
}
