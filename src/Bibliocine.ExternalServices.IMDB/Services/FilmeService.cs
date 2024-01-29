using Bibliocine.Domain.Entities;
using Bibliocine.Domain.Enum;
using Bibliocine.Domain.Interfaces;
using Bibliocine.Domain.ValueObjects;

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
        var generosResult = await _service.FindGenres();
        
        List<Filme> result = new();
        
        foreach (var filme in filmesResult.Data.Results)
        {
        }

        return result;
    }
}

public class ObraComum
{
    public string Title { get; set; }
    public List<string> AuthorsOrDirectors { get; set; }
    public string PublishedDateOrTitleReleaseText { get; set; }
    public string Description { get; set; }
    public List<string> Categories { get; set; }
    public string Language { get; set; }
    public string ImageUrl { get; set; }
}
