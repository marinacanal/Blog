using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories;

public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(BlogContext context) : base(context)
    {
    }  

    public async Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId)
    {
        return await GetAllAsync(p => p.Roles.Any(r => r.Id == roleId));
    }
}