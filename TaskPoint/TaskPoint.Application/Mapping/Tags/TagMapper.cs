using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPoint.Application.Commands.Request.Tag;
using TaskPoint.Application.Commands.Response.Tag;
using TaskPoint.Domain.Model;

namespace TaskPoint.Application.Mapping.Tags
{
    public static class TagMapper
    {
        public static Tag ToEntity(this CreateTagCommand command)
        {
            return new Tag
            {
                TagId = Guid.NewGuid(),
                Name = command.Name,
                Color = command.Color
            };
        }

        public static CreateTagResponse ToResponse(this Tag entity)
        {
            return new CreateTagResponse(entity.TagId);
        }

        public static void UpdateEntity(this UpdateTagCommand command, Tag entity)
        {
            entity.Name = string.IsNullOrWhiteSpace(command.Name) ? entity.Name : command.Name;
            entity.Color = string.IsNullOrWhiteSpace(command.Color) ? entity.Color : command.Color;
        }

        public static GetTagResponse ToGetTagResponse(this Tag entity)
        {
            return new GetTagResponse
            {
                TagId = entity.TagId,
                Name = entity.Name,
                Color = entity.Color
            };
        }
    }
}
