namespace Blog.Application.DTOs.User;

public sealed record UserResponseDto(
    Guid Id,
    string Name,
    string Email,
    DateTime CreatedAt,
    DateTime? EmailConfirmedAt,
    bool IsActive,
    Guid RoleId
)
{}