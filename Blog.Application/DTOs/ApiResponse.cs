namespace Blog.Application.DTOs;

public sealed record ApiResponse<T>(
    bool Success,
    T? Data = default,
    string? Message = null,
    List<string>? Errors = null
)
{
    public static ApiResponse<T> Ok(T data, string? message = null) 
        => new(Success: true, Data: data, Message: message );

    public static ApiResponse<T> Fail(string error) 
        => new(Success: false, Errors: new List<string> { error });
    
    public static ApiResponse<T> Fail(List<string> errors) 
        => new(Success: false, Errors: errors);
}
