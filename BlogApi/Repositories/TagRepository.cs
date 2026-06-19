using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(BlogContext context) : base(context)
    {
    }

    public async Task<Tag?> GetBySlugAsync(string slug)
    {
        return await GetFirstOrDefaultAsync(t => t.Slug == slug);
    }

    public async Task<IEnumerable<Tag>> GetTagsByPostAsync(int postId)
    {
        return await GetAllAsync(t => t.Posts.Any(p => p.Id == postId));
    }
}