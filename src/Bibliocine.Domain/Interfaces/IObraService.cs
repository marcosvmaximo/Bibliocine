using Bibliocine.Domain.Entities;

namespace Bibliocine.Domain.Interfaces;

public interface IObraService<T> where T : Obra
{
    Task<IEnumerable<T>> Pesquisar(string? filtro);
}