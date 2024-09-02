using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPoint.Application.Commands.Request.Tags;
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
                .Produces<GetTaskResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/api/tasks", GetManyTasks)
                .WithName("GetManyTasks")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
                .Produces<GetManyTasksResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/api/tags", GetManyTags)
                .WithName("GetManyTags")
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,UserDefault" })
                .Produces<GetManyTagsResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> CreateTask([FromBody] CreateTaskCommand command, IMediator mediator)
        {
            var response = await mediator.Send(command);

            if (response.Success)
            {
                return Results.Created($"/api/tasks/{response.TaskId}", response);
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

        private static async Task<IResult> UpdateTask([FromBody] UpdateTaskCommand command, IMediator mediator)
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

        private static async Task<IResult> DeleteTask(Guid taskId, IMediator mediator)
        {
            var response = await mediator.Send(new DeleteTaskCommand { TaskId = taskId });

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

        private static async Task<IResult> GetTaskById(Guid taskId, IMediator mediator)
        {
            var response = await mediator.Send(new GetTaskByIdQuery { TaskId = taskId });

            if (response != null)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NoContent();
            }
        }

        private static async Task<IResult> GetManyTasks([FromQuery] int pageNumber, [FromQuery] int pageSize, IMediator mediator)
        {
            var query = new GetManyTasksQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var response = await mediator.Send(query);

            if (response.GetTasksResponse.Any())
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NoContent();
            }
        }

        private static async Task<IResult> GetManyTags([FromQuery] int pageNumber, [FromQuery] int pageSize, IMediator mediator)
        {
            var query = new GetManyTagsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var response = await mediator.Send(query);

            if (response.GetTasksResponse.Any())
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
