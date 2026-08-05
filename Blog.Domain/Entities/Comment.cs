namespace Blog.Domain.Entities;

public class Comment : Entity
{
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsHidden { get; set; }

    public int AuthorId { get; set; }
    public User? Author { get; set; }
    public int PostId { get; set; }
    public Post? Post { get; set; }
}

