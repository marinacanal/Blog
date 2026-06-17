using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context)
        {
        }

        public Task AddTagToPostAsync(int postId, int tagId)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetTagsByPostAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTagFromPostAsync(int postId, int tagId)
        {
            throw new NotImplementedException();
        }
    }
}