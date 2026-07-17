using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Interfaces;

public interface ISeeder
{
    public Task SeedAsync(BlogContext context);
}