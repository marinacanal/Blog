namespace Blog.Domain.Entities;

public class Role : Entity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Permission> Permissions { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}