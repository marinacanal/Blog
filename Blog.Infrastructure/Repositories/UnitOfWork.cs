using Blog.Infrastructure.Context;
using Blog.Application.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogContext _context;
    public IUserRepository Users { get; }
    public IPostRepository Posts { get; }
    public ICommentRepository Comments { get; }
    public ITagRepository Tags { get; }
    public IRoleRepository Roles { get; }
    public IPermissionRepository Permissions { get; }

    public UnitOfWork(BlogContext context, IUserRepository users, IPostRepository posts, ICommentRepository comments, ITagRepository tags, IRoleRepository roles, IPermissionRepository permissions)
    {
        _context = context;
        Users = users;
        Posts = posts;
        Comments = comments;
        Tags = tags;
        Roles = roles;
        Permissions = permissions;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}