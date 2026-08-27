using Blog.Infrastructure.Context;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Application.DTOs;
using Blog.Application.DTOs.Comment;
using System.Linq.Expressions;

namespace Blog.Infrastructure.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(BlogContext context) : base(context)
    {
    }

    public async Task<PagedResult<Comment>> GetCommentsAsync(GetCommentsFilterDto filterDto)
    {
        Expression<Func<Comment, bool>> predicate = c => 
            (!filterDto.AuthorId.HasValue || c.AuthorId == filterDto.AuthorId.Value) &&
            (!filterDto.PostId.HasValue || c.PostId == filterDto.PostId.Value);

        return await GetPagedAsync(filterDto, predicate);
    }

    public async Task UpdateVisibilityAsync(Guid id, bool hidden)
    {
        var comment = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Comentário com o ID {id} não foi encontrado.");
        comment.IsHidden = hidden;

        Update(comment);
    }
}