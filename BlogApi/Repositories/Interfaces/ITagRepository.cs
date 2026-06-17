using BlogApi.Entities;

namespace BlogApi.Repositories.Interfaces;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetBySlugAsync(string slug);
}