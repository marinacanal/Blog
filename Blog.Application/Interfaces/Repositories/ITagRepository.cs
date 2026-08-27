using Blog.Application.DTOs;
using Blog.Application.DTOs.Tag;
using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetBySlugAsync(string slug);
    Task<IEnumerable<Tag>> GetTagsByPostAsync(Guid postId); 
    Task<PagedResult<Tag>> GetTagsAsync(GetTagsFilterDto filterDto); 
}