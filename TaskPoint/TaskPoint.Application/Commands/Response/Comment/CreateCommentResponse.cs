namespace TaskPoint.Application.Commands.Response.Comment;

public record CreateCommentResponse : BaseResponse
{
    public Guid CommentId { get; set; }

}
