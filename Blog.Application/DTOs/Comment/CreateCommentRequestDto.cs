namespace Blog.Application.DTOs.Comment;

public sealed record CreateCommentRequestDto(
    string Content,
    int AuthorId,
    int PostId
)
{ }
