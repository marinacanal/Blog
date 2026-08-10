namespace Blog.Application.DTOs.Tag;

public sealed record CreateTagRequestDto(
    string? Name,
    string? Color
) 
{}
