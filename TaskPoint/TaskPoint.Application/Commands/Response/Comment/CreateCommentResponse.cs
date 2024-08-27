namespace TaskPoint.Application.Commands.Response.Comment;

public class CreateCommentResponse : ResponseBase
{
    public Guid CommentId { get; set; }

    public CreateCommentResponse(Guid commentId)
    {
        CommentId = commentId;
    }
}
