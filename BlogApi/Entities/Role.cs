using System.ComponentModel.DataAnnotations;

namespace BlogApi.Entities;

public class Role
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Permission> Permissions { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}