using System.Dynamic;
using System.Net;
using System.Text.Json;
using Bibliocine.Core.DTO;
using Bibliocine.ExternalServices.IMDB.Configurations;
using Bibliocine.ExternalServices.IMDB.DTO;
using Bibliocine.ExternalServices.IMDB.Models;
using Microsoft.Extensions.Options;

namespace Bibliocine.ExternalServices.IMDB.Services;

public class TMDBFilmeExternalService : ITMDBFilmeExternalService
{
    private readonly TMDBSettings _tmdbSettings;

    public TMDBFilmeExternalService(IOptions<TMDBSettings> tmdbSettings)
    {
        _tmdbSettings = tmdbSettings.Value;
    }
    
    public async Task<ResponseGeneric<TMDBMoviesResult>> FindMovies(string filtro, int page = 1)
    {
        var response = new ResponseGeneric<TMDBMoviesResult>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_tmdbSettings.AccessTokenAuth}");

            var requestUri = $"https://api.themoviedb.org/3/search/movie?query={filtro}&include_adult=false&language=pt-BR&page={page}";
            
            try
            {
                using (var request = await client.GetAsync(requestUri))
                {
                    request.EnsureSuccessStatusCode();
                    var contentBody = await request.Content.ReadAsStringAsync();
                    var objResponse = JsonSerializer.Deserialize<TMDBMoviesResult>(contentBody);

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

    public async Task<ResponseGeneric<TMDBMovieResult>> FindMovieById(string id)
    {
        var response = new ResponseGeneric<TMDBMovieResult>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_tmdbSettings.AccessTokenAuth}");

            var requestUri = $"https://api.themoviedb.org/3/movie/{id}?language=pt-BR";
            
            try
            {
                using (var request = await client.GetAsync(requestUri))
                {
                    request.EnsureSuccessStatusCode();
                    var contentBody = await request.Content.ReadAsStringAsync();
                    var objResponse = JsonSerializer.Deserialize<TMDBMovieResult>(contentBody);

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

    public async Task<ResponseGeneric<TMDBGenreResult>> FindGenres()
    {
        var response = new ResponseGeneric<TMDBGenreResult>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_tmdbSettings.AccessTokenAuth}");

            var requestUri = $"https://api.themoviedb.org/3/genre/movie/list?language=pt";
            
            try
            {
                using (var request = await client.GetAsync(requestUri))
                {
                    request.EnsureSuccessStatusCode();
                    var contentBody = await request.Content.ReadAsStringAsync();
                    var objResponse = JsonSerializer.Deserialize<TMDBGenreResult>(contentBody);

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