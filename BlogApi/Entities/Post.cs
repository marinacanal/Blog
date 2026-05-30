using System.Collections.ObjectModel;

namespace BlogApi.Entities;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Slug { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublishedAt { get; set; }
    public bool IsOccult { get; set; }
    
    public int AuthorId { get; set; }
    public User? Author { get; set; }
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}