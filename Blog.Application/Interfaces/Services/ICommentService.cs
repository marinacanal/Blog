using Blog.Application.DTOs;
using Blog.Application.DTOs.Comment;

namespace Blog.Application.Interfaces.Services;

public interface ICommentService : IScopedDependency
{
    Task<CommentResponseDto> CreateCommentAsync(CreateCommentRequestDto request);
    Task<CommentResponseDto> UpdateCommentVisibilityAsync(int id, bool hidden);
    Task<bool> DeleteCommentAsync(int id);
    Task<PagedResult<CommentResponseDto>> GetCommentsAsync(GetCommentsFilterDto filter);
}
