
namespace Bibliocine.Domain.Entities;

public class Filme : Obra
{
    public Filme()
    {
        
    }

    public string? TituloOriginal { get; set; }
    public string? LinguaOriginal { get; set; }
    public double Nota { get; set; }
}