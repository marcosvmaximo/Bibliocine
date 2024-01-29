using Bibliocine.Domain.Entities;
using Bibliocine.Domain.Enum;
using Bibliocine.Domain.Interfaces;
using Bibliocine.Domain.ValueObjects;
using Bibliocine.ExternalServices.GoogleBooks.Interfaces;

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
        var result = await _service.Find(filtro);

        List<Livro> livros = new();
        foreach (var item in result.Data.Items)
        {
            var livro = new Livro(item.VolumeInfo.Title, null, 12, EGenero.Animacao, ENota.BOM, DateTime.Now, null, EFormatoLivro.eBook, 10, "");
            livros.Add(livro);
        }

        return livros;
    }
}