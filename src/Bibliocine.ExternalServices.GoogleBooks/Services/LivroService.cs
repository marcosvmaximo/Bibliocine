using System.Net;
using Bibliocine.Business.Entities;
using Bibliocine.Business.Enum;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.ExternalServices.GoogleBooks.Interfaces;
using Bibliocine.ExternalServices.GoogleBooks.Models;

namespace Bibliocine.ExternalServices.GoogleBooks.Services;

public class LivroService : IObraService<Livro>
{
    private readonly IGoogleBooksExternalServices _service;
    
    public LivroService(IGoogleBooksExternalServices service)
    {
        _service = service;
    }
    
    public async Task<IEnumerable<Livro>> Pesquisar(string filtro)
    {
        var googleBooksApiResult = await _service.Find(filtro);

        if (googleBooksApiResult.HttpCode != HttpStatusCode.OK)
        {
            return Enumerable.Empty<Livro>();
        }
        
        return googleBooksApiResult.Data!.Books.Select(x => MapToLivro(x));
    }

    public Task<Livro> ObterPorId(string obraId, ETipoObra tipoObra)
    {
        throw new NotImplementedException();
    }

    public Task<Livro> ObterPorId(string obraId)
    {
        throw new NotImplementedException();
    }

    private Livro MapToLivro(BookResult book)
    {
        return new Livro()
        {
            Id = book.Id,
            TipoObra = ETipoObra.LIVRO,
            Titulo = book.VolumeInfo?.Title,
            ImagemUrl = book.VolumeInfo?.ImageLinks?.Thumbnail,
            Descricao = book.VolumeInfo?.Description,
            Generos = book.VolumeInfo?.Categories,
            AutorOuDiretor = book.VolumeInfo?.Authors?[0],
            Editora = book.VolumeInfo?.Publisher,
            NumeroPaginas = book.VolumeInfo.PageCount,
            Lingua = book.VolumeInfo?.Language,
            DataLancamento = book.VolumeInfo?.PublishedDate
        };
    }
}