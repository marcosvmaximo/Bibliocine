using Bibliocine.Business.Enum;
using Bibliocine.Core;

namespace Bibliocine.Business;

public abstract class Obra
{
    protected Obra()
    {
        
    }

    public string? Id { get; set; }
    public ETipoObra TipoObra { get; set; }
    public string? Titulo { get; set; }
    public string? ImagemUrl { get; set; }
    public string? AutorOuDiretor { get; set; }
    public List<string?> Generos { get; set; }
    public string? Descricao { get; set; }
    public string? DataLancamento { get; set; }
}