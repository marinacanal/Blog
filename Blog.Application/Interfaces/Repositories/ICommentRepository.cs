using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid id);
    Task UpdateVisibilityAsync(Guid id, bool hidden);
}