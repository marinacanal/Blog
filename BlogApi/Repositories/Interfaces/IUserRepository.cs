using BlogApi.Entities;

namespace BlogApi.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
}