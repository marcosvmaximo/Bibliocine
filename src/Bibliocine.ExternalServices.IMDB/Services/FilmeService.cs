using System.Net;
using Bibliocine.Domain.Entities;
using Bibliocine.Domain.Enum;
using Bibliocine.Domain.Interfaces;
using Bibliocine.ExternalServices.IMDB.Models;

namespace Bibliocine.ExternalServices.IMDB.Services;

public class FilmeService : IObraService<Filme>
{
    private readonly ITMDBFilmeExternalService _service;

    public FilmeService(ITMDBFilmeExternalService service)
    {
        _service = service;
    }
    
    public async Task<IEnumerable<Filme>> Pesquisar(string filtro)
    {
        var filmesResult = await _service.FindMovies(filtro);
        var todosGenerosResult = await _service.FindGenres();

        if (filmesResult.HttpCode != HttpStatusCode.OK || todosGenerosResult.HttpCode != HttpStatusCode.OK)
        {
            return Enumerable.Empty<Filme>();
        }
        
        return filmesResult.Data.Results.Select(movie => MapToFilme(movie, todosGenerosResult.Data.Genres));
    }
    
    private Filme MapToFilme(MovieResult filme, List<Genre> generos)
    {
        // Obtém o nome dos generos do filme
        var nomesGeneros = filme.GenreIds
            .Select(generoId => generos.FirstOrDefault(x => x.Id == generoId)?.Name)
            .ToList();

        return new Filme()
        {
            Id = filme.Id.ToString(),
            TipoObra = ETipoObra.FILME,
            Titulo = filme?.Title,
            ImagemUrl = $"https://image.tmdb.org/t/p/w500/{filme.PosterPath}",
            Descricao = filme?.Overview,
            Generos = nomesGeneros,
            TituloOriginal = filme?.OriginalTitle,
            LinguaOriginal = filme?.OriginalLanguage,
            Nota = filme.VoteAverage,
            DataLancamento = filme?.ReleaseDate
        };
    }
}
