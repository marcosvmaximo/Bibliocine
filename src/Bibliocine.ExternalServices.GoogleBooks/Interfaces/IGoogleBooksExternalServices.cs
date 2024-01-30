using Bibliocine.Core.DTO;
using Bibliocine.ExternalServices.GoogleBooks.Models;

namespace Bibliocine.ExternalServices.GoogleBooks.Interfaces;

public interface IGoogleBooksExternalServices
{
    Task<ResponseGeneric<GoogleBookResult>> Find(string filtro);
    Task<ResponseGeneric<BookResult>> FindById(string id);
}