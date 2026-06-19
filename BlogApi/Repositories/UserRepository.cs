using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BlogContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await GetFirstOrDefaultAsync(u => u.Email == email);
    }
}