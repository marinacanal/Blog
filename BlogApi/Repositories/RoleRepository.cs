using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(BlogContext context) : base(context)
    {
    }
}