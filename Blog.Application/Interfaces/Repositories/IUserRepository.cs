using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> UpdatePasswordHashAsync(int id, string newPasswordHash);
    Task<bool> ActivateAsync(int id);
    Task<bool> DeactivateAsync(int id);
}