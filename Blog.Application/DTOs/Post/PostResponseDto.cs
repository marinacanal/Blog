namespace Blog.Application.DTOs.Post;

public sealed record PostResponseDto(
    int Id,
    string? Title,
    string? Content,
    string? Slug,
    DateTime CreatedAt,
    DateTime PublishedAt,
    bool IsOccult,
    int AuthorId,
    ICollection<string> TagNames
)
{ }
