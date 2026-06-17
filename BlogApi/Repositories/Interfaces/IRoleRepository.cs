using BlogApi.Entities;

namespace BlogApi.Repositories.Interfaces;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId);
    
    Task AddPermissionToRoleAsync(int roleId, int permissionId);
    Task RemovePermissionFromRoleAsync(int roleId, int permissionId);
}