using Bibliocine.API.Controller.Common;
using Bibliocine.Domain;
using Bibliocine.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliocine.API.Controller;

[Route("v1/catalogo")]
[Authorize]
public class CatalogoController : CommonController
{
    private readonly IObraRepository _repository;

    public CatalogoController(IObraRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    [AllowAnonymous] 
    public async Task<ActionResult<IEnumerable<Obra>>> Pesquisar([FromQuery] string filtro)
    {
        var obras = await _repository.PesquisarObras(filtro);

        // Criar os objetos corretamente
        
        // Mapeamento para view model
        if (obras == null)
        {
            return BadRequest();
        }
        
        return Ok(obras);
    }
    
    //
    // // Necessita estar autenticado, e que envie o usuario em questão
    //     // Como chamar o modulo
    //     // Preciso enviar o usuario logado?
    //     
    //     
    //     
    // // 1. Criar autenticacao e autorizacao
    // // 2. Integrar a API de terceiros
    // // 3. Realizar o filtro e buscar na APi de terceiro
    // // 4. Exibir
    // // 5. Tratar os favoritos
    // [HttpGet("favoritos")]
    // public async Task<ActionResult<IEnumerable<Obra>>> ObterFavoritos()
    // {
    //     
    // }
    //
    // [HttpPost("{idObra:guid}/favoritos")]
    // public async Task<ActionResult> AdicionarFavorito([FromRoute] Guid idObra)
    // {
    //     
    // }
    //
    //
    // [HttpDelete("{idObra:guid}/favoritos")]
    // public async Task<ActionResult> RemoverFavorito([FromRoute] Guid idObra)
    // {
    //     
    // }
}