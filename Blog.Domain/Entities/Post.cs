using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities;

public class Post : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime PublishedAt { get; set; }
    public bool IsOccult { get; set; }

    public int AuthorId { get; set; }
    public User? Author { get; set; }
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}