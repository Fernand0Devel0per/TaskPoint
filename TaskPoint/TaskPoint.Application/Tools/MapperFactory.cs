using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Request.User;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Application.Commands.Response.User;
using TaskPoint.Application.Mapping.Comments;
using TaskPoint.Application.Mapping.Projects;
using TaskPoint.Application.Mapping.Tags;
using TaskPoint.Application.Mapping.Tasks;
using TaskPoint.Application.Mapping.Users;
using TaskPoint.Domain.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Application.Tools;

public static class MapperFactory
{
    public static TDestination MapTo<TSource, TDestination>(this TSource source)
    {
        return source switch
        {
            CreateUserCommand command when typeof(TDestination) == typeof(User) => (TDestination)(object)command.ToEntity(),
            User entity when typeof(TDestination) == typeof(CreateUserResponse) => (TDestination)(object)entity.ToResponse(),
            User entity when typeof(TDestination) == typeof(GetUserResponse) => (TDestination)(object)entity.ToGetUserResponse(),

            CreateProjectCommand command when typeof(TDestination) == typeof(Project) => (TDestination)(object)command.ToEntity(),
            Project entity when typeof(TDestination) == typeof(CreateProjectResponse) => (TDestination)(object)entity.ToResponse(),
            Project entity when typeof(TDestination) == typeof(GetProjectResponse) => (TDestination)(object)entity.ToGetProjectResponse(),

            CreateTagCommand command when typeof(TDestination) == typeof(Tag) => (TDestination)(object)command.ToEntity(),
            Tag entity when typeof(TDestination) == typeof(CreateTagResponse) => (TDestination)(object)entity.ToResponse(),
            Tag entity when typeof(TDestination) == typeof(GetTagResponse) => (TDestination)(object)entity.ToGetTagResponse(),

            CreateTaskCommand command when typeof(TDestination) == typeof(Task) => (TDestination)(object)command.ToEntity(),
            Task entity when typeof(TDestination) == typeof(CreateTaskResponse) => (TDestination)(object)entity.ToResponse(),
            Task entity when typeof(TDestination) == typeof(GetTaskResponse) => (TDestination)(object)entity.ToGetTaskResponse(),

            CreateCommentCommand command when typeof(TDestination) == typeof(Comment) => (TDestination)(object)command.ToEntity(),
            Comment entity when typeof(TDestination) == typeof(CreateCommentResponse) => (TDestination)(object)entity.ToResponse(),
            Comment entity when typeof(TDestination) == typeof(GetCommentResponse) => (TDestination)(object)entity.ToGetCommentResponse(),
            

            UpdateUserCommand command when typeof(TDestination) == typeof(User) => throw new InvalidOperationException("Use UpdateEntity method for UpdateUserCommand."),
            UpdateProjectCommand command when typeof(TDestination) == typeof(Project) => throw new InvalidOperationException("Use UpdateEntity method for UpdateProjectCommand."),
            UpdateTagCommand command when typeof(TDestination) == typeof(Tag) => throw new InvalidOperationException("Use UpdateEntity method for UpdateTagCommand."),
            UpdateTaskCommand command => throw new InvalidOperationException("Use UpdateEntity method for UpdateTaskCommand."),
            UpdateCommentCommand command => throw new InvalidOperationException("Use UpdateEntity method for UpdateCommentCommand."),

            _ => throw new InvalidOperationException($"Mapper not found for the provided types: {typeof(TSource).Name} to {typeof(TDestination).Name}.")
        };
    }
}
