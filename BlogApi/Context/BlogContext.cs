using Microsoft.EntityFrameworkCore;
using BlogApi.Entities;

namespace BlogApi.Context;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = 1, Name = "posts.create", Description = "Criar novos posts" },
            new Permission { Id = 2, Name = "comments.create", Description = "Criar novos comentários" },

            new Permission { Id = 3, Name = "posts.manage", Description = "Gerenciar todos os posts" },
            new Permission { Id = 4, Name = "comments.manage", Description = "Moderar todos os comentários" },
            new Permission { Id = 5, Name = "tags.manage", Description = "Gerenciar todas as tags" },
            new Permission { Id = 6, Name = "users.manage", Description = "Gerenciar usuários e cargos" }
        );
    }
}
