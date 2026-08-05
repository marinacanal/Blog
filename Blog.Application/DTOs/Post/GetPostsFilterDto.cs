namespace Blog.Application.DTOs.Post;

public class GetPostsFilterDto
{
    public int? AuthorId { get; set; }
    public ICollection<string>? TagSlugs { get; set; }
}
