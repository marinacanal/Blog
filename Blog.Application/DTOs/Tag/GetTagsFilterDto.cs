namespace Blog.Application.DTOs.Tag;

public sealed record GetTagsFilterDto(
    string? Name
) : PaginationParams
{ }