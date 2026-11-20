using Microsoft.AspNetCore.Diagnostics;
using Blog.Application.DTOs;
using FluentValidation;

namespace Blog.Api.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        int statusCode;
        string message;
        List<string> errors;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = StatusCodes.Status400BadRequest;
                message = "Erro de validação.";
                errors = validationException.Errors
                    .Select(error => error.ErrorMessage)
                    .Distinct()
                    .ToList();
                break;

            case ArgumentException argumentException:
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
                errors = new List<string> { exception.Message };
                break;

            case KeyNotFoundException keyNotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
                errors = new List<string> { exception.Message };
                break;

            default:
                statusCode = StatusCodes.Status500InternalServerError;
                message = "Ocorreu um erro interno no servidor do Blog.";
                errors = new List<string> { "Ocorreu um erro inesperado." };
                break;
        }

        if (statusCode >= 500)
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
        else
            _logger.LogWarning(exception, "Request failed: {Message}", exception.Message);

        if (_env.IsDevelopment())
            errors.Add($"Exception: {exception.Message} StackTrace: {exception.StackTrace}");

        httpContext.Response.StatusCode = statusCode;

        var response = new ApiResponse<object>(
            Success: false,
            Message: message,
            Errors: errors
        );

        await httpContext.Response.WriteAsJsonAsync(
            response,
            cancellationToken
        );
        
        return true;
    }
}
