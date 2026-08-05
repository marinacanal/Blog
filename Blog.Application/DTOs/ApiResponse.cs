namespace Blog.Application.DTOs;

public class ApiResponse<T> where T : class
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ApiResponse<T> Ok(T data, string? message = null) 
        => new ApiResponse<T>() { Success = true, Data = data, Message = message };

    public static ApiResponse<T> Fail(string error) 
        => new ApiResponse<T>() { Success = false, Errors = new List<string> { error } };
    
    public static ApiResponse<T> Fail(List<string> errors) 
        => new ApiResponse<T>() { Success = false, Errors = errors };
}
