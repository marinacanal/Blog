using Blog.Infrastructure.Context;
using Blog.Domain.Entities;
using Blog.Application.Interfaces;
using Blog.Application.DTOs;
using Blog.Application.DTOs.Tag;
using System.Linq.Expressions;

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

    public async Task<IEnumerable<Tag>> GetTagsByPostAsync(Guid postId)
    {
        return await GetAllAsync(t => t.Posts.Any(p => p.Id == postId));
    }

    public async Task<PagedResult<Tag>> GetTagsAsync(GetTagsFilterDto filterDto)
    {
        Expression<Func<Tag, bool>> predicate = t => String.IsNullOrWhiteSpace(filterDto.Name) || t.Name.ToUpper().Contains(filterDto.Name.ToUpper());

        return await GetPagedAsync(filterDto, predicate);
    }
}