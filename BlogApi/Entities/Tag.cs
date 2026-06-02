using System.ComponentModel.DataAnnotations;

namespace BlogApi.Entities;

public class Tag
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Color { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = [];
}