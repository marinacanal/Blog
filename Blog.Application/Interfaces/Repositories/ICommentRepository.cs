using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int id);
    Task UpdateVisibilityAsync(int id, bool hidden);
}