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
}