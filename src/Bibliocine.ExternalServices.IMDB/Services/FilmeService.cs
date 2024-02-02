using System.Net;
using Bibliocine.Business.Entities;
using Bibliocine.Business.Enum;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.ExternalServices.IMDB.DTO;
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
        
        return filmesResult.Data!.Results.Select(movie => MapToFilme(movie, todosGenerosResult.Data.Genres));
    }

    public Task<Filme> ObterPorId(string obraId, ETipoObra tipoObra)
    {
        throw new NotImplementedException();
    }

    public async Task<Filme> ObterPorId(string obraId)
    {
        var filme = await _service.FindMovieById(obraId);

        if (filme.HttpCode != HttpStatusCode.OK)
        {
            return null;
        }
        
        return MapToFilme(filme.Data!);
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
            ImagemUrl = filme.PosterPath != null ? $"https://image.tmdb.org/t/p/w500/{filme.PosterPath}" : null,
            Descricao = filme?.Overview,
            Generos = nomesGeneros,
            TituloOriginal = filme?.OriginalTitle,
            LinguaOriginal = filme?.OriginalLanguage,
            Nota = filme.VoteAverage,
            DataLancamento = filme?.ReleaseDate
        };
    }
    
    private Filme MapToFilme(TMDBMovieResult filme)
    {
        var nomesGeneros = filme.Genres
            .Select(genero => genero.Name)
            .ToList();

        return new Filme()
        {
            Id = filme.Id.ToString(),
            TipoObra = ETipoObra.FILME,
            Titulo = filme?.Title,
            ImagemUrl = $"https://image.tmdb.org/t/p/w500/{filme.PosterPath}",
            Descricao = filme?.Overview,
            Generos = filme?.Genres?.Select(x => x.Name)?.ToList(),
            TituloOriginal = filme?.OriginalTitle,
            LinguaOriginal = filme?.OriginalLanguage,
            Nota = filme.VoteAverage,
            DataLancamento = filme?.ReleaseDate
        };
    }
    
}
