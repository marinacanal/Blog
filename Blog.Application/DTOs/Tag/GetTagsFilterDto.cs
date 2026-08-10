namespace Blog.Application.DTOs.Tag;

public sealed record GetTagsFilterDto(
    string? Name,
    Guid? PostId,
    int Page,
    int PageSize
)
{ }