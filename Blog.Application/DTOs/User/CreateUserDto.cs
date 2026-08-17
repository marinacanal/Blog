namespace Blog.Application.DTOs.User;

public sealed record CreateUserDto(
    string Name,
    string Email,
    string Password
)
{}
