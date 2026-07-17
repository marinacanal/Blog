using System.Linq.Expressions;
using Blog.Infrastructure.Context;
using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BlogContext _context;
    protected readonly DbSet<T> _dbSet;
   
    public GenericRepository(BlogContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate)
    {
        IQueryable<T> query = _dbSet;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _dbSet;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}