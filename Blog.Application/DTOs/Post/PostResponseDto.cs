namespace Blog.Application.DTOs.Post;

public class PostResponseDto : ApiResponse<PostResponseDto>
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime PublishedAt { get; set; }
    public bool IsOccult { get; set; }
    public int AuthorId { get; set; }
    public ICollection<string> TagNames { get; set; } = [];
}
