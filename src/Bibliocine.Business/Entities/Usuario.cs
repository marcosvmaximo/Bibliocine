using Bibliocine.Core;

namespace Bibliocine.Business.Entities;

public class Usuario : Entity
{
    private List<Favorito> _favoritos;
    
    public Usuario(string nome, DateTime dataNascimento, string email)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;

        _favoritos = new List<Favorito>();
    }

    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Email { get; private set; }
    public IReadOnlyCollection<Favorito> Favoritos => _favoritos;

    public void AdicionarFavorito(Favorito favorito)
    {
        if (favorito is null)
            throw new ArgumentNullException("Favorito informado não é válida.");

        if (_favoritos.Count > 30)
            throw new Exception("Número maximo de favoritos atingido.");
        
        _favoritos.Add(favorito);
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}