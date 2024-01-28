using Bibliocine.Core;

namespace Bibliocine.Domain.Entities;

public class Usuario : Entity
{
    private List<Obra> _favoritos;
    
    public Usuario(string nome, DateTime dataNascimento, string email)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;

        _favoritos = new List<Obra>();
    }

    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Email { get; private set; }
    public IReadOnlyCollection<Obra> Favoritos => _favoritos;

    public void AdicionarFavorito(Obra obra)
    {
        if (obra is null)
            throw new ArgumentNullException("Obra informada não é válida.");
        
        _favoritos.Add(obra);
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}