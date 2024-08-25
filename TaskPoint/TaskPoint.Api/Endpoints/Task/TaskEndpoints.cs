using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Commands.Response.Task;

namespace TaskPoint.Api.Endpoints.Task
{
    public static class TaskEndpoints
    {
        public static void ConfigureTaskEndpoints(this WebApplication app)
        {
            app.MapPost("/api/tasks", CreateTask)
                .WithName("CreateTask")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
                .Accepts<CreateTaskCommand>("application/json")
                .Produces<CreateTaskResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapPut("/api/tasks", UpdateTask)
                .WithName("UpdateTask")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
                .Accepts<UpdateTaskCommand>("application/json")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapDelete("/api/tasks/{taskId:guid}", DeleteTask)
                .WithName("DeleteTask")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status500InternalServerError);
            app.MapGet("/api/tasks/{taskId:guid}", GetTaskById)
                .WithName("GetTaskById")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
                .Produces<GetTasResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> CreateTask(IMediator mediator, [FromBody] CreateTaskCommand command)
        {
            try
            {
                var response = await mediator.Send(command);
                return Results.Created($"/api/tasks/{response.TaskId}", response);
            }
            catch (Exception)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private static async Task<IResult> UpdateTask(IMediator mediator, [FromBody] UpdateTaskCommand command)
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

        private static async Task<IResult> DeleteTask(IMediator mediator, [FromRoute] Guid taskId)
        {
            try
            {
                var success = await mediator.Send(new DeleteTaskCommand { TaskId = taskId });
                return success ? Results.Ok() : Results.BadRequest();
            }
            catch (Exception)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private static async Task<IResult> GetTaskById(IMediator mediator, [FromRoute] Guid taskId)
        {
            try
            {
                var response = await mediator.Send(new GetTaskByIdQuery { TaskId = taskId });
                return response != null ? Results.Ok(response) : Results.NoContent();
            }
            catch (Exception)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
