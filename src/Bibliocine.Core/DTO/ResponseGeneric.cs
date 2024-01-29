using System.Dynamic;
using System.Net;

namespace Bibliocine.Core.DTO;

public class ResponseGeneric<T> where T : class
{
    public HttpStatusCode HttpCode { get; set; }
    public T? Data { get; set; }
    public ExpandoObject? Errors { get; set; }
}