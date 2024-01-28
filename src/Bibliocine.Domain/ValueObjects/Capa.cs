using Bibliocine.Core;

namespace Bibliocine.Domain.ValueObjects;

public class Capa : ValueObject
{
    public string Nome { get; private set; }
    public string Upload { get; private set; }
}