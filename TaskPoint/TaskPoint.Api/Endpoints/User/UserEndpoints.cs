using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.User;

namespace TaskPoint.Api.Endpoints.User
{
    public static class UserEndpoints
    {
        public static void ConfigureUserEndpoints(this WebApplication app)
        {
            app.MapPost("/api/users", CreateUser)
                .WithName("CreateUser")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
                .Accepts<CreateUserCommand>("application/json")
                .Produces<CreateUserResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapPut("/api/users", UpdateUser)
                .WithName("UpdateUser")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
                .Accepts<UpdateUserCommand>("application/json")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapDelete("/api/users/{userId:guid}", DeleteUser)
                .WithName("DeleteUser")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/api/users/{userId:guid}", GetUserById)
                .WithName("GetUserById")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
                .Produces<GetUserResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> CreateUser([FromBody] CreateUserCommand command, IMediator mediator)
        {
            var response = await mediator.Send(command);

            if (response.Success)
            {
                return Results.Created($"/api/users/{response.UserId}", response);
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

        private static async Task<IResult> UpdateUser([FromBody] UpdateUserCommand command, IMediator mediator)
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

        private static async Task<IResult> DeleteUser(Guid userId, IMediator mediator)
        {
            var response = await mediator.Send(new DeleteUserCommand { UserId = userId });

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

        private static async Task<IResult> GetUserById(Guid userId, IMediator mediator)
        {
            var response = await mediator.Send(new GetUserByIdQuery { UserId = userId });

            if (response != null)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NoContent();
            }
        }
    }
}
