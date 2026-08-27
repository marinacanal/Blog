namespace Blog.Application.DTOs.Post;

public sealed record GetPostsFilterDto(
    Guid? AuthorId,
    IReadOnlyCollection<string>? TagSlugs,
    bool? IncludeHidden
) : PaginationParams
{ }