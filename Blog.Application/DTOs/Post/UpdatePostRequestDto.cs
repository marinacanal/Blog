namespace Blog.Application.DTOs.Post;

public sealed record UpdatePostRequestDto(
    string? Title,
    string? Content
)
{ }
