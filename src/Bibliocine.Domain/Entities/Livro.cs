using Bibliocine.Domain.Enum;
using Bibliocine.Domain.ValueObjects;

namespace Bibliocine.Domain.Entities;

public class Livro : Obra
{
    public Livro(
        string titulo,
        Capa capa,
        int classicacaoEtaria,
        EGenero genero,
        ENota avaliacao,
        DateTime anoLancamento,
        string autor,
        EFormatoLivro formato,
        int numeroPaginas,
        string descricao) : base(
            titulo,
            capa,
            classicacaoEtaria,
            genero,
            avaliacao,
            anoLancamento)
    {
        Autor = autor;
        Formato = formato;
        NumeroPaginas = numeroPaginas;
        Descricao = descricao;
    }

    public string Autor { get; private set; }
    public EFormatoLivro Formato { get; private set; }
    public int NumeroPaginas { get; private set; }
    public string Descricao { get; private set; }
    
    public override void Validar()
    {
        throw new NotImplementedException();
    }
}