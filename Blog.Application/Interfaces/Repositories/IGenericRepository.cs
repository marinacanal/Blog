using System.Linq.Expressions;
using Blog.Application.DTOs;

namespace Blog.Application.Interfaces;

public interface IGenericRepository<T> : IScopedDependency where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<PagedResult<T>> GetPagedAsync(PaginationParams pagination, Expression<Func<T, bool>>? predicate = null);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}