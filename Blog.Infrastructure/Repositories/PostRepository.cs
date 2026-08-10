using Blog.Infrastructure.Context;
using Blog.Domain.Entities;
using Blog.Application.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(BlogContext context) : base(context)
    {
    }

    public async Task<Post?> GetBySlugAsync(string slug)
    {
        return await GetFirstOrDefaultAsync(p => p.Slug == slug);
    }

    public async Task<IEnumerable<Post>> GetPostsByAuthorIdAsync(Guid authorId)
    {
        return await GetAllAsync(p => p.AuthorId == authorId);
    }

    public async Task UpdateVisibilityAsync(Guid id, bool hidden)
    {
        var post = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Post com o ID {id} não foi encontrado.");
        post.IsHidden = hidden;

        Update(post);
    }
}