using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IPermissionRepository : IGenericRepository<Permission>
{
    Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId);
}