using Bibliocine.Core.DTO;
using Bibliocine.ExternalServices.IMDB.DTO;
using Bibliocine.ExternalServices.IMDB.Models;

namespace Bibliocine.ExternalServices.IMDB;

public interface ITMDBFilmeExternalService
{
    Task<ResponseGeneric<TMDBMoviesResult>> FindMovies(string filtro, int page = 1);
    Task<ResponseGeneric<TMDBMovieResult>> FindMovieById(string id);
    Task<ResponseGeneric<TMDBGenreResult>> FindGenres();
}