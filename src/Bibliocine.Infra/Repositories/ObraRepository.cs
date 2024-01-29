using Bibliocine.Core.Data;
using Bibliocine.Domain;
using Bibliocine.Domain.Entities;
using Bibliocine.Domain.Interfaces;

namespace Bibliocine.Infra.Repositories;

public class ObraRepository : IObraRepository
{
    private readonly IObraService<Livro> _livroService;
    private readonly IObraService<Filme> _filmeService;

    public ObraRepository(IObraService<Filme> filmeService, IObraService<Livro> livroService)
    {
        _filmeService = filmeService;
        _livroService = livroService;
    }
    
    public async Task<IEnumerable<Obra>> PesquisarObras(string? filtro)
    {
        List<Obra> result = new();
        
        var filmes = await _filmeService.Pesquisar(filtro);
        var livros = await _livroService.Pesquisar(filtro);
        
        result.AddRange(filmes);
        result.AddRange(livros);

        return result;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

}