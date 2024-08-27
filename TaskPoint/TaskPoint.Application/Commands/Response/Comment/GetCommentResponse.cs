﻿namespace TaskPoint.Application.Commands.Response.Comment;

public class GetCommentResponse : ResponseBase
{
    public Guid CommentId { get; set; }
    public string Content { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
}
