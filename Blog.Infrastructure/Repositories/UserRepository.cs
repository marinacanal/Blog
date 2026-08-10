using Blog.Infrastructure.Context;
using Blog.Domain.Entities;
using Blog.Application.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BlogContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await GetFirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> UpdatePasswordHashAsync(Guid id, string newPasswordHash)
    {
        var user = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Usuário com o ID {id} não foi encontrado.");
        user.PasswordHash = newPasswordHash;
        Update(user);
        return true;
    }

    public async Task<bool> ActivateAsync(Guid id)
    {
        var user = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Usuário com o ID {id} não foi encontrado.");
        user.IsActive = true;
        Update(user);
        return true;
    }

    public async Task<bool> DeactivateAsync(Guid id)
    {
        var user = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Usuário com o ID {id} não foi encontrado.");
        user.IsActive = false;
        Update(user);
        return true;
    }
}