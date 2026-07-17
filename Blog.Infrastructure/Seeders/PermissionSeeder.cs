using Blog.Domain.Entities;
using Blog.Infrastructure.Context;
using Blog.Infrastructure.Interfaces;

namespace Blog.Infrastructure.Seeders;

public class PermissionSeeder : ISeeder
{
    public async Task SeedAsync(BlogContext context)
    {
        if (!context.Permissions.Any())
        {
            var permissions = new List<Permission>
            {
                new Permission { Name = "posts.create", Description = "Criar novos posts" },
                new Permission { Name = "comments.create", Description = "Criar novos comentários" },

                new Permission { Name = "posts.manage", Description = "Gerenciar todos os posts" },
                new Permission { Name = "comments.manage", Description = "Moderar todos os comentários" },
                new Permission { Name = "tags.manage", Description = "Gerenciar todas as tags" },
                new Permission { Name = "users.manage", Description = "Gerenciar usuários e cargos" }
            };

            context.Permissions.AddRange(permissions);
            await context.SaveChangesAsync();
        }
    }
}