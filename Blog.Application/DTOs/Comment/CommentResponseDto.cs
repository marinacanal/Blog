namespace Blog.Application.DTOs.Comment;

public sealed record CommentResponseDto(
    Guid Id,
    string Content,
    DateTime CreatedAt,
    bool IsHidden,
    Guid AuthorId,
    Guid PostId
)
{ }
