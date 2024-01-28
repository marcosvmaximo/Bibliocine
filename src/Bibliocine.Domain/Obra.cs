using Bibliocine.Core;

namespace Bibliocine.Domain;

public abstract class Obra : Entity, IAggregateRoot
{
    public string Titulo { get; private set; }
}