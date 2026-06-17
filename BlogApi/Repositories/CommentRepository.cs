using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context)
        {
        }

        public Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVisibilityAsync(int id, bool oculto)
        {
            throw new NotImplementedException();
        }
    }
}