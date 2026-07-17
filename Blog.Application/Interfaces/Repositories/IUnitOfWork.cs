namespace Blog.Application.Interfaces;

public interface IUnitOfWork : IDisposable, IScopedDependency
{
    IUserRepository Users { get; }
    IPostRepository Posts { get; }
    ICommentRepository Comments { get; }
    ITagRepository Tags { get; }
    IRoleRepository Roles { get; }
    IPermissionRepository Permissions { get; }

    Task<int> CommitAsync();
}