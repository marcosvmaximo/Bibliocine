namespace Bibliocine.Core.DTO;

public class BaseResponse
{
    public int HttpCode { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Result { get; set; }
}