using Blog.Application.DTOs.User;

namespace Blog.Application.Interfaces.Services;

public interface IUserService : IScopedDependency
{
    Task<UserResponseDto> CreateUserAsync(CreateUserDto request);
    Task<UserResponseDto> UpdateUserAsync(Guid userId, UpdateUserDto request);
    Task<UserResponseDto> ChangePasswordAsync(Guid userId, ChangePasswordDto request);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<UserResponseDto> GetUserByIdAsync(Guid userId);
}