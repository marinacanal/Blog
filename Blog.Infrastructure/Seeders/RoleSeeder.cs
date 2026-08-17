using Blog.Infrastructure.Context;
using Blog.Infrastructure.Interfaces;

namespace Blog.Infrastructure.Seeders;

public class RoleSeeder : ISeeder
{
    public async Task SeedAsync(BlogContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = RolePermissions.GetRolesWithPermissions();

            context.Roles.AddRange(roles);
            await context.SaveChangesAsync();
        }
    }
}