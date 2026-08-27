using Blog.Application.DTOs;
using Blog.Application.DTOs.Post;
using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<Post?> GetBySlugAsync(string slug);
    Task<PagedResult<Post>> GetPostsAsync(GetPostsFilterDto filterDto);
    Task UpdateVisibilityAsync(Guid id, bool hidden);
}