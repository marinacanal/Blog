using BlogApi.Entities;

namespace BlogApi.Repositories.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<Post?> GetBySlugAsync(string slug);

    Task<IEnumerable<Tag>> GetTagsByPostAsync(int postId);
    Task AddTagToPostAsync(int postId, int tagId);
    Task RemoveTagFromPostAsync(int postId, int tagId);
}