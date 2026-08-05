namespace Blog.Application.DTOs.Post;

public class CreatePostRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public ICollection<int> TagIds { get; set; } = [];
}
