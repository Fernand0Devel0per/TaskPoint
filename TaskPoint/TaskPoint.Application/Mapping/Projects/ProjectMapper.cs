using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPoint.Application.Commands.Request.Project;
using TaskPoint.Application.Commands.Response.Project;
using TaskPoint.Domain.Model;

namespace TaskPoint.Application.Mapping.Projects
{
    public static class ProjectMapper
    {
        public static Project ToEntity(this CreateProjectCommand command)
        {
            return new Project
            {
                ProjectId = Guid.NewGuid(),
                UserId = command.UserId,
                Name = command.Name,
                Description = command.Description,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
        }

        public static CreateProjectResponse ToResponse(this Project entity)
        {
            return new CreateProjectResponse();
        }

        public static void UpdateEntity(this UpdateProjectCommand command, Project entity)
        {
            entity.Name = string.IsNullOrWhiteSpace(command.Name) ? entity.Name : command.Name;
            entity.Description = string.IsNullOrWhiteSpace(command.Description) ? entity.Description : command.Description;
            entity.StartDate = command.StartDate != default ? command.StartDate : entity.StartDate;
            entity.EndDate = command.EndDate != default ? command.EndDate : entity.EndDate;
            entity.UpdatedDate = DateTime.UtcNow;
        }

        public static GetProjectResponse ToGetProjectResponse(this Project entity)
        {
            return new GetProjectResponse
            {
                ProjectId = entity.ProjectId,
                Name = entity.Name,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                UserId = entity.UserId
            };
        }
    }
}
