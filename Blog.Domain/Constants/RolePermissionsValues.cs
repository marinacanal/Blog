using Blog.Domain.Constants;
using Blog.Domain.Entities;

public static class RolePermissions
{
    private static readonly Dictionary<string, IReadOnlyCollection<Permission>> Map = new()
    {
        [Roles.Admin] =
        [
            PermissionValues.CommentsManage,
            PermissionValues.PostsManage,
            PermissionValues.TagsManage,
            PermissionValues.UsersManage
        ],

        [Roles.Visitor] = 
        [
            PermissionValues.CommentsCreate
        ]
    };

    public static IReadOnlyCollection<Role> GetRolesWithPermissions()
    {
        return Map.Select(rp => new Role
        {
            Name = rp.Key,
            Permissions = rp.Value.ToList()
        }).ToList();
    }
}