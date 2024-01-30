using Bibliocine.Business.Entities;
using Bibliocine.Core.Data;

namespace Bibliocine.Business.Services.Interfaces;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task Salvar(Usuario user);
    Task Atualizar(Usuario user);
    Task<Usuario?> ObterPorId(Guid id);
    Task AdicionarFavorito(Favorito favorito);
    Task DeletarFavorito(Favorito favorito);
}