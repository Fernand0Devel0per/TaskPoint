namespace TaskPoint.Application.Commands.Response.Comment;

public record CreateCommentResponse : BaseResponse
{
    public Guid CommentId { get; set; }

    public CreateCommentResponse(Guid commentId)
    {
        CommentId = commentId;
    }
}
