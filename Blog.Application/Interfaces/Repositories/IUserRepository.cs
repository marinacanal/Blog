using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}