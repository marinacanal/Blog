namespace Blog.Domain.Entities;

public class Tag : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = [];
}