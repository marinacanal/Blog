namespace Blog.Application.DTOs.User;

public sealed record UpdateUserDto(
    string? Name,
    string? Email,
    bool? IsActive,
    Guid? RoleId
)
{}