using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(BlogContext context) : base(context)
    {
    }

    public async Task<Post?> GetBySlugAsync(string slug)
    {
        return await GetFirstOrDefaultAsync(p => p.Slug == slug);
    }

    public async Task<IEnumerable<Post>> GetPostsByAuthorIdAsync(int authorId)
    {
        return await GetAllAsync(p => p.AuthorId == authorId);
    }
}