using System.ComponentModel.DataAnnotations;

namespace BlogApi.Entities;

public class Comment
{
    public int Id { get; set; }

    [Required]
    [StringLength(1000)]
    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsOccult { get; set; }

    public int AuthorId { get; set; }
    public User? Author { get; set; }
    public int PostId { get; set; }
    public Post? Post { get; set; }
}

