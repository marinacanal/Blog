using BlogApi.Entities;

namespace BlogApi.Repositories.Interfaces;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int id);
    Task UpdateVisibilityAsync(int id, bool oculto);
}