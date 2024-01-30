namespace Bibliocine.Core.DTO;

public class BaseResponse
{
    public int HttpCode { get; set; }
    public bool Sucess { get; set; }
    public string? Message { get; set; }
    public object? Result { get; set; }
}