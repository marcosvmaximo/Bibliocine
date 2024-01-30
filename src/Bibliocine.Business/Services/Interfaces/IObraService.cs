using Bibliocine.Business.Entities;
using Bibliocine.Business.Enum;

namespace Bibliocine.Business.Services.Interfaces;

public interface IObraService<T> where T : Obra
{
    Task<IEnumerable<T>> Pesquisar(string? filtro);
    Task<T> ObterPorId(string obraId, ETipoObra tipoObra);
    Task<T> ObterPorId(string obraId);
}