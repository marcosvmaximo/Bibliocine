using Bibliocine.Core;

namespace Bibliocine.Domain.ValueObjects;

public class Capa : ValueObject
{
    public Capa(string nome, string upload)
    {
        Nome = nome;
        Upload = upload;
    }

    public string Nome { get; private set; }
    public string Upload { get; private set; }
    
    public override void Validar()
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Nome;
        yield return Upload;
    }
}