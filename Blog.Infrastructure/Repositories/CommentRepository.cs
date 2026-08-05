using Blog.Infrastructure.Context;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Infrastructure.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(BlogContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int id)
    {
        return await GetAllAsync(c => c.PostId == id);
    }

    public async Task UpdateVisibilityAsync(int id, bool hidden)
    {
        var comment = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Comentário com o ID {id} não foi encontrado.");
        comment.IsHidden = hidden;

        Update(comment);
    }
}