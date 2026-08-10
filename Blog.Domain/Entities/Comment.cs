namespace Blog.Domain.Entities;

public class Comment : Entity
{
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsHidden { get; set; }

    public Guid AuthorId { get; set; }
    public User? Author { get; set; }
    public Guid PostId { get; set; }
    public Post? Post { get; set; }
}

