using Blog.Application.DTOs;
using Blog.Application.DTOs.Comment;
using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<PagedResult<Comment>> GetCommentsAsync(GetCommentsFilterDto filterDto);
    Task UpdateVisibilityAsync(Guid id, bool hidden);
}