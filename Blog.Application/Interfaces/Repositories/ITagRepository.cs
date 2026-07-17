using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetBySlugAsync(string slug);
    Task<IEnumerable<Tag>> GetTagsByPostAsync(int id); 
}