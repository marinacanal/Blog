using BlogApi.Entities;

namespace BlogApi.Repositories.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<Post?> GetBySlugAsync(string slug);
    Task<IEnumerable<Post>> GetPostsByAuthorIdAsync(int authorId);
}