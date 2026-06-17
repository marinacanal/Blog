using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Repositories.Interfaces;

namespace BlogApi.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(BlogContext context) : base(context)
        {
        }

        public Task AddPermissionToRoleAsync(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task RemovePermissionFromRoleAsync(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }
    }
}