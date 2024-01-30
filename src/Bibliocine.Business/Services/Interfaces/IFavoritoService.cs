using Bibliocine.Business.Entities;
using Bibliocine.Business.Enum;
using Bibliocine.Business.ViewModels;

namespace Bibliocine.Business.Services.Interfaces;

public interface IFavoritoService
{
    Task AdicionarFavorito(Guid userId, string obraId, ETipoObra tipoObra);
    Task<IEnumerable<Obra?>> ObterFavoritosPorUsuario(Guid usuarioId);
    Task RemoverFavorito(Guid userId, string obraId);
}