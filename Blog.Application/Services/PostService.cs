using Blog.Application.DTOs;
using Blog.Application.DTOs.Post;
using Blog.Application.Interfaces;
using Blog.Application.Interfaces.Services;
using Blog.Application.Mappers;
using Blog.Domain.Entities;
using FluentValidation;

namespace Blog.Application.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreatePostRequestDto> _createPostValidator;
    private readonly IValidator<UpdatePostRequestDto> _updatePostValidator;

    public PostService(
        IUnitOfWork unitOfWork,
        IValidator<CreatePostRequestDto> createPostValidator,
        IValidator<UpdatePostRequestDto> updatePostValidator)
    {
        _unitOfWork = unitOfWork;
        _createPostValidator = createPostValidator;
        _updatePostValidator = updatePostValidator;
    }

    public async Task<PostResponseDto> CreatePostAsync(CreatePostRequestDto request)
    {
        await _createPostValidator.ValidateAndThrowAsync(request);

        if(await _unitOfWork.Users.GetByIdAsync(request.AuthorId) is null)
            throw new KeyNotFoundException($"Autor com o ID {request.AuthorId} não foi encontrado.");

        var post = new Post
        {
            Title = request.Title.Trim(),
            Content = request.Content.Trim(),
            Slug = await GenerateUniqueSlug(request.Title),
            AuthorId = request.AuthorId,
            PublishedAt = DateTime.UtcNow,
            IsHidden = false,
            Tags = new List<Tag>()
        };

        if (request.TagIds != null && request.TagIds.Count > 0)
        {
            var tagsId = request.TagIds.Distinct().ToList();
            var tags = await _unitOfWork.Tags.GetTagsByIdsAsync(tagsId);

            post.Tags = tags.ToList();
        }

        await _unitOfWork.Posts.AddAsync(post);
        await _unitOfWork.CommitAsync();

        return post.MapToResponseDto();
    }

    public async Task<PostResponseDto> UpdatePostAsync(Guid id, UpdatePostRequestDto request)
    {
        await _updatePostValidator.ValidateAndThrowAsync(request);

        var post = await _unitOfWork.Posts.GetByIdWithTagsAsync(id)
            ?? throw new KeyNotFoundException($"Post com o ID {id} não foi encontrado.");

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            post.Title = request.Title.Trim();
            post.Slug = await GenerateUniqueSlug(post.Title, id);
        }

        if (!string.IsNullOrWhiteSpace(request.Content))
        {
            post.Content = request.Content.Trim();
        }

        _unitOfWork.Posts.Update(post);
        await _unitOfWork.CommitAsync();

        return post.MapToResponseDto();
    }

    public async Task<PostResponseDto> UpdatePostVisibilityAsync(Guid id, bool hidden)
    {
        var post = await _unitOfWork.Posts.GetByIdWithTagsAsync(id)
            ?? throw new KeyNotFoundException($"Post com o ID {id} não foi encontrado.");

        post.IsHidden = hidden;
        _unitOfWork.Posts.Update(post);
        await _unitOfWork.CommitAsync();

        return post.MapToResponseDto();
    }

    public async Task<bool> DeletePostAsync(Guid id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Post com o ID {id} não foi encontrado.");

        _unitOfWork.Posts.Delete(post);
        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<PagedResult<PostResponseDto>> GetPostsAsync(GetPostsFilterDto? filter = null)
    {
        var request = filter ?? new GetPostsFilterDto(
            AuthorId: null, 
            TagSlugs: null, 
            IncludeHidden: false);

        var result = await _unitOfWork.Posts.GetPostsAsync(request);

        return new PagedResult<PostResponseDto>(
            result.Items.Select(p => p.MapToResponseDto()).ToList(), 
            result.Page, 
            result.PageSize, 
            result.TotalCount);
    }

    public async Task<PostResponseDto> GetPostByIdAsync(Guid postId)
    {
        var post = await _unitOfWork.Posts.GetByIdWithTagsAsync(postId)
            ?? throw new KeyNotFoundException($"Post com o ID {postId} não foi encontrado.");

        return post.MapToResponseDto();
    }

    private static string GenerateSlug(string title)
    {
        var slug = title.Trim();

        slug = slug.Replace(" ", "-");
        slug = slug.Replace("_", "-");
        slug = slug.Replace("/", "-");
        slug = slug.Replace("\\", "-");
        slug = slug.ToLowerInvariant();
        slug = string.Join("-", slug.Split('-', StringSplitOptions.RemoveEmptyEntries));

        return slug;
    }

    private async Task<string> GenerateUniqueSlug(string title, Guid? excludePostId = null)
    {
        var slug = GenerateSlug(title);
        var candidate = slug;
        var counter = 1;

        while (true)
        {
            var existingPost = await _unitOfWork.Posts.GetBySlugAsync(candidate);
            if (existingPost is null || (excludePostId.HasValue && existingPost.Id == excludePostId.Value))
            {
                return candidate;
            }

            candidate = $"{slug}-{counter}";
            counter++;
        }
    }
}
