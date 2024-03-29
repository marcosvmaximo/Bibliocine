using Bibliocine.Business.Enum;
using Bibliocine.Core;

namespace Bibliocine.Business.Entities;

public class Favorito : Entity
{
    public Favorito(Usuario usuario, Guid usuarioId, ETipoObra tipoObra, string obraId)
    {
        Usuario = usuario;
        UsuarioId = usuarioId;
        TipoObra = tipoObra;
        ObraId = obraId;
    }
    
    protected Favorito(){}
    
    public ETipoObra TipoObra { get; private set; }
    public string ObraId { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; }
}