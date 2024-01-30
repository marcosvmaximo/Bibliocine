using Bibliocine.Business.Enum;
using Bibliocine.Business.ViewModels;

namespace Bibliocine.Business.Services.Interfaces;

public interface IUsuarioService
{
    Task RegistrarUsuario(RegistrarUsuarioViewModel model);
    Task<bool> AdicionarFavorito(Guid userId, string obraId, ETipoObra tipoObra);
    Task<IEnumerable<Obra?>> ObterFavoritosPorUsuario(Guid usuarioId);
}