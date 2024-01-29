using Bibliocine.Core.Data;
using Bibliocine.Domain.Entities;

namespace Bibliocine.Domain.Interfaces;

public interface IObraRepository : IRepository<Filme>
{
    Task<IEnumerable<Obra>> PesquisarObras(string? filtro);
}