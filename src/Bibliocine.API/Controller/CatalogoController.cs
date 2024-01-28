using Bibliocine.API.Controller.Common;
using Bibliocine.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliocine.API.Controller;

[Route("v1/catalogo")]
[Authorize]
public class CatalogoController : CommonController
{
    [HttpGet]
    [AllowAnonymous] 
    public async Task<ActionResult<IEnumerable<Obra>>> Pesquisar(string filtro)
    {
        
    }

    // Necessita estar autenticado, e que envie o usuario em questão
        // Como chamar o modulo
        // Preciso enviar o usuario logado?
    [HttpGet("favoritos")] 
    public async Task<ActionResult<IEnumerable<Obra>>> ObterFavoritos()
    {
        
    }

    [HttpPost("{idObra:guid}/favoritos")]
    public async Task<ActionResult> AdicionarFavorito([FromRoute] Guid idObra)
    {
        
    }
    
    
    [HttpDelete("{idObra:guid}/favoritos")]
    public async Task<ActionResult> RemoverFavorito([FromRoute] Guid idObra)
    {
        
    }
}