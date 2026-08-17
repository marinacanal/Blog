using Blog.Domain.Entities;

namespace Blog.Domain.Constants;

public static class PermissionValues
{
    public static IReadOnlyCollection<Permission> GetPermissions() => 
        [
            CommentsCreate,
            CommentsManage,
            PostsManage,
            TagsManage,
            UsersManage
        ];
        

    public static readonly Permission CommentsCreate = new Permission { Name = "comments.create", Description = "Criar comentários" };
    public static readonly Permission CommentsManage = new Permission { Name = "comments.manage", Description = "Gerenciar comentários" };
    public static readonly Permission PostsManage = new Permission { Name = "posts.manage", Description = "Gerenciar posts" };
    public static readonly Permission TagsManage = new Permission { Name = "tags.manage", Description = "Gerenciar tags" };
    public static readonly Permission UsersManage = new Permission { Name = "users.manage", Description = "Gerenciar usuários" }    ;
}