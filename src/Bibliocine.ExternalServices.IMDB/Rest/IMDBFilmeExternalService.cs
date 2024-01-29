using System.Dynamic;
using System.Net;
using System.Text.Json;
using Bibliocine.Core.DTO;
using Bibliocine.ExternalServices.IMDB.DTO;

namespace Bibliocine.ExternalServices.IMDB.Services;

public class IMDBFilmeExternalService : IIMDBFilmeExternalService
{
    public async Task<ResponseGeneric<IMDBResult>> Find(string filtro)
    {
        var response = new ResponseGeneric<IMDBResult>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "fd091c0000mshc8c764498dc23d7p1c920fjsn674adf8f3035");
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "imdb146.p.rapidapi.com");

            var requestUri = $"https://imdb146.p.rapidapi.com/v1/find/?query={filtro}";
            
            try
            {
                using (var request = await client.GetAsync(requestUri))
                {
                    request.EnsureSuccessStatusCode();
                    var contentBody = await request.Content.ReadAsStringAsync();
                    var objResponse = JsonSerializer.Deserialize<IMDBResult>(contentBody);

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