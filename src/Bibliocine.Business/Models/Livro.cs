
namespace Bibliocine.Business.Entities;

public class Livro : Obra
{
    public Livro()
    {
        
    }
    
    public string? Editora { get; set; }
    public int NumeroPaginas { get; set; }
    public string? Lingua { get; set; }
}