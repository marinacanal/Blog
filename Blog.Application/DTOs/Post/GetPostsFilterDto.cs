namespace Blog.Application.DTOs.Post;

public sealed record GetPostsFilterDto(
    int? AuthorId,
    IReadOnlyCollection<string>? TagSlugs,
    int Page,
    int PageSize
)
{ }