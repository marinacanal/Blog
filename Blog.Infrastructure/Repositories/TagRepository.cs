using Blog.Infrastructure.Context;
using Blog.Domain.Entities;
using Blog.Application.Interfaces;

namespace Blog.Infrastructure.Repositories;

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