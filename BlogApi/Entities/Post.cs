using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Entities;

public class Post
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(10000)]
    public string Content { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Slug { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime PublishedAt { get; set; }
    public bool IsOccult { get; set; }

    public int AuthorId { get; set; }
    public User? Author { get; set; }
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}