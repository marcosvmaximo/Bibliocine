using System.Dynamic;
using System.Net;
using System.Text.Json;
using Bibliocine.Core.DTO;
using Bibliocine.ExternalServices.GoogleBooks.Interfaces;
using Bibliocine.ExternalServices.GoogleBooks.Models;

namespace Bibliocine.ExternalServices.GoogleBooks.Rest;

public class GoogleBooksExternalServices : IGoogleBooksExternalServices
{
    public async Task<ResponseGeneric<GoogleBookResult>> Find(string filtro)
    {
        var response = new ResponseGeneric<GoogleBookResult>();

        using (var client = new HttpClient())
        {
            var requestUri = $"https://www.googleapis.com/books/v1/volumes?q={filtro}";
            
            try
            {
                using (var request = await client.GetAsync(requestUri))
                {
                    request.EnsureSuccessStatusCode();
                    var contentBody = await request.Content.ReadAsStringAsync();
                    var objResponse = JsonSerializer.Deserialize<GoogleBookResult>(contentBody);

                    response.HttpCode = request.StatusCode;

                    if (request.IsSuccessStatusCode)
                        response.Data = objResponse;
                    else
                        response.Errors = JsonSerializer.Deserialize<ExpandoObject>(contentBody);
                    
                }
            }
            catch (HttpRequestException ex)
            {
                response.HttpCode = HttpStatusCode.InternalServerError;
                response.Errors = JsonSerializer.Deserialize<ExpandoObject>(ex.Message);
            }
            catch (Exception ex)
            {
                response.HttpCode = HttpStatusCode.InternalServerError;
                response.Errors = JsonSerializer.Deserialize<ExpandoObject>(ex.Message);
            }
        }

        return response;
    }
}