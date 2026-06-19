using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(BlogContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int id)
    {
        return await GetAllAsync(c => c.PostId == id);
    }

    public async Task UpdateVisibilityAsync(int id, bool oculto)
    {
        var comment = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Comentário com o ID {id} não foi encontrado.");
        comment.IsOccult = oculto;

        Update(comment);
    }
}