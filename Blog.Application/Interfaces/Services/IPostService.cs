using Blog.Application.DTOs;
using Blog.Application.DTOs.Post;

namespace Blog.Application.Interfaces.Services;

public interface IPostService : IScopedDependency
{
    Task<PostResponseDto> CreatePostAsync(CreatePostRequestDto request);
    Task<PostResponseDto> UpdatePostAsync(int id, UpdatePostRequestDto request);
    Task<PostResponseDto> UpdatePostVisibilityAsync(int id, bool hidden);
    Task<bool> DeletePostAsync(int id);
    Task<PagedResult<PostResponseDto>> GetPostsAsync(GetPostsFilterDto? filter = null);
    Task<IEnumerable<PostResponseDto>> GetPostsByIdAsync(int postId);
    Task<IEnumerable<PostResponseDto>> GetPostsByUserAsync(int userId, bool includeHidden = false);
}