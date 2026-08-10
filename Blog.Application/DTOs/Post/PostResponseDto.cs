namespace Blog.Application.DTOs.Post;

public sealed record PostResponseDto(
    Guid Id,
    string? Title,
    string? Content,
    string? Slug,
    DateTime CreatedAt,
    DateTime PublishedAt,
    bool IsHidden,
    Guid AuthorId,
    ICollection<string> TagNames
)
{ }
