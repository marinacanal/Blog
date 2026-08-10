namespace Blog.Application.DTOs.Post;

public sealed record CreatePostRequestDto(
    string? Title,
    string? Content,
    Guid AuthorId,
    IReadOnlyCollection<Guid>? TagIds 
)
{ }
