
namespace Bibliocine.Domain.Entities;

public class Livro : Obra
{
    public Livro()
    {
        
    }
    
    public string? Autor { get; set; }
    public string? Editora { get; set; }
    public int NumeroPaginas { get; set; }
    public string? Lingua { get; set; }
}