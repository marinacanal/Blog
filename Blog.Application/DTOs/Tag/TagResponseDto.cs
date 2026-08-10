namespace Blog.Application.DTOs.Tag;

public sealed record TagResponseDto(
    Guid Id,
    string Name,
    string Slug,
    string Color 
)
{}
