using Blog.Application.DTOs.Post;
using Blog.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

public class PostController : AbstractController
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPostById(Guid id)
    {
        var post = await _postService.GetPostByIdAsync(id);

        return Ok(post);
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] GetPostsFilterDto filter)
    {
        var posts = await _postService.GetPostsAsync(filter);

        return Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(
        [FromBody] CreatePostRequestDto request)
    {
        var post = await _postService.CreatePostAsync(request);

        return Created(
            post,
            nameof(GetPostById),
            new { id = post.Id });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePost(
        Guid id,
        [FromBody] UpdatePostRequestDto request)
    {
        var post = await _postService.UpdatePostAsync(id, request);

        return UpdateOk(post);
    }

    [HttpPatch("{id:guid}/visibility")]
    public async Task<IActionResult> UpdatePostVisibility(
        Guid id,
        [FromBody] bool hidden)
    {
        var post = await _postService.UpdatePostVisibilityAsync(id, hidden);

        return Ok(post, "Visibilidade do post atualizada com sucesso.");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        await _postService.DeletePostAsync(id);

        return DeleteOk();
    }
}