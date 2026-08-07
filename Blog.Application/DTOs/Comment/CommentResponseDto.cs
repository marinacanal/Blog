namespace Blog.Application.DTOs.Comment;

public sealed record CommentResponseDto(
    int Id,
    string Content,
    DateTime CreatedAt,
    bool IsHidden,
    int AuthorId,
    int PostId
)
{ }
