using Bibliocine.Core;
using Bibliocine.Domain.Enum;

namespace Bibliocine.Domain;

public abstract class Obra : IAggregateRoot
{
    protected Obra()
    {
        
    }

    public string? Id { get; set; }
    public ETipoObra TipoObra { get; set; }
    public string? Titulo { get; set; }
    public string? ImagemUrl { get; set; }
    public string? Descricao { get; set; }
    public List<string?> Generos { get; set; }
    public string? DataLancamento { get; set; }
}