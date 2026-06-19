using BlogApi.Entities;

namespace BlogApi.Repositories.Interfaces;

public interface IPermissionRepository : IGenericRepository<Permission>
{
    Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId);
}