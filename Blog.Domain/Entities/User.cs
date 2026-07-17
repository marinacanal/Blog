using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }

    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public ICollection<Post> Posts { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}