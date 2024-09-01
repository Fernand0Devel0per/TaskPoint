using TaskPoint.Application.Commands.Request.Task;
using TaskPoint.Application.Commands.Response.Task;
using TaskPoint.Domain.Tools.Enums;
using Task = TaskPoint.Domain.Model.Task;
using TaskStatus = TaskPoint.Domain.Tools.Enums.TaskStatus;

namespace TaskPoint.Application.Mapping.Tasks
{
    public static class TaskMapper
    {
        public static Task ToEntity(this CreateTaskCommand command)
        {
            return new Task
            {
                TaskId = Guid.NewGuid(),
                Title = command.Title,
                Description = command.Description,
                UserId = command.UserId,
                DueDate = command.DueDate,
                Priority = string.IsNullOrEmpty(command.Priority) ? TaskPriority.Low : command.Priority.ToEnum<TaskPriority>(),
                Status = string.IsNullOrEmpty(command.Status) ? TaskStatus.Pending : command.Status.ToEnum<TaskStatus>(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDated = DateTime.UtcNow,
            };
        }

        public static CreateTaskResponse ToResponse(this Task entity)
        {
            return new CreateTaskResponse {TaskId = entity.TaskId };
        }

        public static void UpdateEntity(this UpdateTaskCommand command, Task entity)
        {
            entity.Title = string.IsNullOrWhiteSpace(command.Title) ? entity.Title : command.Title;
            entity.Description = string.IsNullOrWhiteSpace(command.Description) ? entity.Description : command.Description;
            entity.DueDate = command.DueDate != default ? command.DueDate : entity.DueDate;
            entity.Priority = string.IsNullOrWhiteSpace(command.Priority) ? entity.Priority : command.Priority.ToEnum<TaskPriority>();
            entity.Status = string.IsNullOrWhiteSpace(command.Status) ? entity.Status : command.Status.ToEnum<TaskStatus>();
            entity.UpdatedDated = DateTime.UtcNow;
        }

        public static GetTaskResponse ToGetTaskResponse(this Task entity)
        {
            return new GetTaskResponse
            {
                TaskId = entity.TaskId,
                Title = entity.Title,
                Description = entity.Description,
                Status = entity.Status.ToString(),
                Priority = entity.Priority.ToString(),
                UserId = entity.UserId
            };
        }

    }
}
