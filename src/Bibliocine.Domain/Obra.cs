using Bibliocine.Core;
using Bibliocine.Domain.Entities;
using Bibliocine.Domain.Enum;
using Bibliocine.Domain.ValueObjects;

namespace Bibliocine.Domain;

public abstract class Obra : Entity, IAggregateRoot
{
    protected Obra(string titulo, Capa capa, int classicacaoEtaria, EGenero genero, ENota avaliacao, DateTime anoLancamento)
    {
        Titulo = titulo;
        Capa = capa;
        ClassicacaoEtaria = classicacaoEtaria;
        Genero = genero;
        Avaliacao = avaliacao;
        AnoLancamento = anoLancamento;
    }

    public string Titulo { get; private set; }
    public Capa Capa { get; private set; }
    public int ClassicacaoEtaria { get; private set; }
    public EGenero Genero { get; private set; }
    public ENota Avaliacao { get; private set; }
    public DateTime AnoLancamento { get; private set; }
    
    public Usuario Usuario { get; private set; }
}