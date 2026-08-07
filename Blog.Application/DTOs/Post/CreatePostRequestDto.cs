namespace Blog.Application.DTOs.Post;

public sealed record CreatePostRequestDto(
    string? Title,
    string? Content,
    int AuthorId,
    IReadOnlyCollection<int>? TagIds 
)
{ }
