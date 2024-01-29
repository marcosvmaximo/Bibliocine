using System.Dynamic;
using System.Net;

namespace Bibliocine.Core.DTO;

/// <summary>
/// Resposta padrão para chamadas Externas
/// </summary>
/// <typeparam name="T">Response body</typeparam>
public class ResponseGeneric<T> where T : class
{
    public HttpStatusCode HttpCode { get; set; }
    public T? Data { get; set; }
    public ExpandoObject? Errors { get; set; }
}