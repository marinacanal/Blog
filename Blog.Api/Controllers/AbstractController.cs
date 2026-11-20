using Blog.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class AbstractController : ControllerBase
{
    protected IActionResult Ok<T>(T data, string? message = null)
        => base.Ok(ApiResponse<T>.Ok(data, message));
    
    protected IActionResult UpdateOk<T>(T data)
        => base.Ok(ApiResponse<T>.Ok(data, "Objeto atualizado com sucesso."));

    protected IActionResult DeleteOk()
        => base.Ok(ApiResponse<bool>.Ok(true, "Objeto excluído com sucesso."));

    protected IActionResult Created<T>(
        T data,
        string actionName,
        object routeValues)
    {
        return CreatedAtAction(
            actionName,
            routeValues,
            ApiResponse<T>.Ok(data, "Objeto criado com sucesso.")
        );
    }
}