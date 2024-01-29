using Bibliocine.Core.DTO;
using Bibliocine.ExternalServices.IMDB.DTO;

namespace Bibliocine.ExternalServices.IMDB;

public interface IIMDBFilmeExternalService
{
    Task<ResponseGeneric<IMDBResult>> Find(string filtro);
}