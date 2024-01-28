using Bibliocine.Domain.Enum;
using Bibliocine.Domain.ValueObjects;

namespace Bibliocine.Domain.Entities;

public class Filme : Obra
{
    public Filme(
        string titulo,
        Capa capa,
        int classicacaoEtaria,
        EGenero genero,
        ENota avaliacao,
        DateTime anoLancamento,
        string diretor,
        EFormatoFilme formato,
        float duracao,
        string sinopse)  : base(
            titulo,
            capa,
            classicacaoEtaria,
            genero,
            avaliacao,
            anoLancamento)
    {
        Diretor = diretor;
        Formato = formato;
        Duracao = duracao;
        Sinopse = sinopse;
    }

    public string Diretor { get; private set; }
    public EFormatoFilme Formato { get; private set; }
    public float Duracao { get; private set; }
    public string Sinopse { get; private set; }
    
    public override void Validar()
    {
        throw new NotImplementedException();
    }
}