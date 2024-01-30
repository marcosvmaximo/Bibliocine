using Bibliocine.Business.Entities;
using Bibliocine.Core.Data;

namespace Bibliocine.Business.Services.Interfaces;

public interface IUsuarioRepository : IRepository
{
    Task Salvar(Usuario user);
    Task<Usuario?> ObterPorId(Guid id);
}