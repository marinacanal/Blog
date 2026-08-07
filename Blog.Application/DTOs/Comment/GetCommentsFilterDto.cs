namespace Blog.Application.DTOs.Comment;

public sealed record GetCommentsFilterDto(
    int? AuthorId,
    int? PostId,
    int Page,
    int PageSize
)
{ }
