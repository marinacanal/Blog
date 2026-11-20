using Blog.Infrastructure.Context;
using Blog.Domain.Entities;
using Blog.Application.Interfaces;
using Blog.Application.DTOs;
using Blog.Application.DTOs.Post;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(BlogContext context) : base(context)
    {
    }

    public async Task<Post?> GetByIdWithTagsAsync(Guid id)
        => await GetFirstOrDefaultAsync(p => p.Id == id, query => query.Include(p => p.Tags));

    public async Task<Post?> GetBySlugAsync(string slug)
        => await GetFirstOrDefaultAsync(p => p.Slug == slug);

    public async Task<PagedResult<Post>> GetPostsAsync(GetPostsFilterDto filterDto)
    {
        var includeHidden = filterDto.IncludeHidden ?? false;

        Expression<Func<Post, bool>> predicate = p =>
            (!filterDto.AuthorId.HasValue || p.AuthorId == filterDto.AuthorId.Value) &&
            (filterDto.TagSlugs == null || !filterDto.TagSlugs.Any() || p.Tags.Any(t => filterDto.TagSlugs.Contains(t.Slug))) &&
            (includeHidden || !p.IsHidden);

        return await GetPagedAsync(
            filterDto, 
            predicate,
            query => query.Include(p => p.Tags));
    }

    public async Task UpdateVisibilityAsync(Guid id, bool hidden)
    {
        var post = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Post com o ID {id} não foi encontrado.");
        post.IsHidden = hidden;

        Update(post);
    }
}