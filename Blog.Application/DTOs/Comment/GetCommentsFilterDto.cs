namespace Blog.Application.DTOs.Comment;

public sealed record GetCommentsFilterDto(
    Guid? AuthorId,
    Guid? PostId
) : PaginationParams
{ } 
