using Bibliocine.Business.Entities;
using Bibliocine.Business.Enum;
using Bibliocine.Business.Services.Interfaces;

namespace Bibliocine.Business.Services;

public class ObraService : IObraService<Obra>
{
    private readonly IObraService<Livro> _livroService;
    private readonly IObraService<Filme> _filmeService;

    public ObraService(IObraService<Filme> filmeService, IObraService<Livro> livroService)
    {
        _filmeService = filmeService;
        _livroService = livroService;
    }
    
    public async Task<IEnumerable<Obra>> Pesquisar(string? filtro)
    {
        List<Obra> obras = new();
        
        var filmes = await _filmeService.Pesquisar(filtro);
        var livros = await _livroService.Pesquisar(filtro);
        
        obras.AddRange(filmes);
        obras.AddRange(livros);
        
        return obras;
    }

    public async Task<Obra> ObterPorId(string obraId, ETipoObra tipoObra)
    {
        if (tipoObra == ETipoObra.LIVRO)
        {
            return await _livroService.ObterPorId(obraId);
        }

        return await _filmeService.ObterPorId(obraId);
    }

    public Task<Obra> ObterPorId(string obraId)
    {
        throw new NotImplementedException();
    }
}