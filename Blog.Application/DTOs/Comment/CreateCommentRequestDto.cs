namespace Blog.Application.DTOs.Comment;

public sealed record CreateCommentRequestDto(
    string Content,
    Guid AuthorId,
    Guid PostId
)
{ }
