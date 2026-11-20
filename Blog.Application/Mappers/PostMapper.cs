using Blog.Application.DTOs.Post;
using Blog.Domain.Entities;

namespace Blog.Application.Mappers;

public static class PostMapper
{
    public static PostResponseDto MapToResponseDto(this Post post)
    {
        return new PostResponseDto(
            post.Id,
            post.Title,
            post.Content,
            post.Slug,
            post.CreatedAt,
            post.PublishedAt,
            post.IsHidden,    
            post.AuthorId,
            post.Tags.Select(t => t.Name).ToList()
        );
    }
}