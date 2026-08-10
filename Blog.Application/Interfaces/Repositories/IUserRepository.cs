using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> UpdatePasswordHashAsync(Guid id, string newPasswordHash);
    Task<bool> ActivateAsync(Guid id);
    Task<bool> DeactivateAsync(Guid id);
}