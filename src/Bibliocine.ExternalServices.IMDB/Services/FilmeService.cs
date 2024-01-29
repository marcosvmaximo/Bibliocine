using Bibliocine.Domain.Entities;
using Bibliocine.Domain.Enum;
using Bibliocine.Domain.Interfaces;
using Bibliocine.Domain.ValueObjects;

namespace Bibliocine.ExternalServices.IMDB.Services;

public class FilmeService : IObraService<Filme>
{
    private readonly IIMDBFilmeExternalService _service;

    public FilmeService(IIMDBFilmeExternalService service)
    {
        _service = service;
    }
    
    public async Task<IEnumerable<Filme>> Pesquisar(string filtro)
    {
        var respose = await _service.Find(filtro);

        List<Filme> filmes = new();
        
        foreach (var result in respose.Data.TitleResponse.Results)
        {
            // Deixar os objetos pertinentes às informações retornadas
            // Pdronizar retorno
            var filme = new Filme(result.TitleNameText, null, 12, EGenero.Animacao, ENota.BOM, DateTime.Now, null, EFormatoFilme.Digital, 10, "");
            filmes.Add(filme);
        }

        return filmes;
    }
}