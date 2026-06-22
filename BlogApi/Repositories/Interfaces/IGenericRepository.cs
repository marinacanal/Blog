using System.Linq.Expressions;
using BlogApi.Common;

namespace BlogApi.Repositories.Interfaces;

public interface IGenericRepository<T> : IScopedDependency where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}