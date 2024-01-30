using Bibliocine.Core;
using Microsoft.AspNetCore.Identity;

namespace Bibliocine.Business.Entities;

public class Usuario : IdentityUser<Guid>, IAggregateRoot
{
    private List<Favorito> _favoritos;
    
    public Usuario(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;

        _favoritos = new List<Favorito>();
    }
    
    protected Usuario(){}

    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public IReadOnlyCollection<Favorito> Favoritos => _favoritos;

    public void AdicionarFavorito(Favorito favorito)
    {
        if (favorito is null)
            throw new ArgumentNullException("Favorito informado não é válida.");

        if (_favoritos.Count > 30)
            throw new Exception("Número maximo de favoritos atingido.");
        
        _favoritos.Add(favorito);
    }
}