using Blog.Infrastructure.Context;
using Blog.Domain.Entities;
using Blog.Application.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(BlogContext context) : base(context)
    {
    }
}