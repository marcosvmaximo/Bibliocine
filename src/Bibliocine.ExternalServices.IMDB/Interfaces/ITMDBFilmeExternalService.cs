using Bibliocine.Core.DTO;
using Bibliocine.ExternalServices.IMDB.DTO;
using Bibliocine.ExternalServices.IMDB.Models;

namespace Bibliocine.ExternalServices.IMDB;

public interface ITMDBFilmeExternalService
{
    Task<ResponseGeneric<TMDBResult>> FindMovies(string filtro, int page = 1);
    Task<ResponseGeneric<GenreResult>> FindGenres();
}