namespace TaskPoint.Application.Commands.Response.Comment;

public class CreateCommentResponse
{
    public Guid CommentId { get; set; }

    public CreateCommentResponse(Guid commentId)
    {
        CommentId = commentId;
    }
}
