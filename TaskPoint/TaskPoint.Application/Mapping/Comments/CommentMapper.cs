using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPoint.Application.Commands.Request.Comment;
using TaskPoint.Application.Commands.Response.Comment;
using TaskPoint.Domain.Model;

namespace TaskPoint.Application.Mapping.Comments
{
    public static class CommentMapper
    {
        public static Comment ToEntity(this CreateCommentCommand command)
        {
            return new Comment
            {
                CommentId = Guid.NewGuid(),
                TaskId = command.TaskId,
                UserId = command.UserId,
                Content = command.Content,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };
        }

        public static CreateCommentResponse ToResponse(this Comment entity)
        {
            return new CreateCommentResponse {CommentId = entity.CommentId };
        }

        public static void UpdateEntity(this UpdateCommentCommand command, Comment entity)
        {
            entity.Content = string.IsNullOrWhiteSpace(command.Content) ? entity.Content : command.Content;
            entity.UpdatedDate = DateTime.UtcNow;
        }

        public static GetCommentResponse ToGetCommentResponse(this Comment entity)
        {
            return new GetCommentResponse
            {
                CommentId = entity.CommentId,
                Content = entity.Content,
                TaskId = entity.TaskId,
                UserId = entity.UserId
            };
        }
    }

}
