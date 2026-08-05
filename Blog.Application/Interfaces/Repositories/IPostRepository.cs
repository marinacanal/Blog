using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<Post?> GetBySlugAsync(string slug);
    Task<IEnumerable<Post>> GetPostsByAuthorIdAsync(int authorId);
    Task UpdateVisibilityAsync(int id, bool hidden);
}