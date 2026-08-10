using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<Post?> GetBySlugAsync(string slug);
    Task<IEnumerable<Post>> GetPostsByAuthorIdAsync(Guid authorId);
    Task UpdateVisibilityAsync(Guid id, bool hidden);
}