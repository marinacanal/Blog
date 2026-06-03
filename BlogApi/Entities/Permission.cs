using System.ComponentModel.DataAnnotations;

namespace BlogApi.Entities;

public class Permission
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [StringLength(200)]
    public string Description { get; set; } = string.Empty;

    public ICollection<Role> Roles { get; set; } = [];
}