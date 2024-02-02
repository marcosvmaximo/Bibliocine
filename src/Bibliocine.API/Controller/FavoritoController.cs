using System.Security.Claims;
using Bibliocine.API.Controller.Common;
using Bibliocine.Core.Application;
using Bibliocine.Business;
using Bibliocine.Business.Enum;
using Bibliocine.Business.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliocine.API.Controller;

[Route("api/v1/usuario")]
[Authorize]
public class FavoritoController : CommonController
{
    private readonly IFavoritoService _service;

    public FavoritoController(INotifyHandler notifyHandler, IFavoritoService service) : base(notifyHandler)
    {
        _service = service;
    }
    
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<Obra>>> ObterFavoritos([FromRoute]Guid userId)
    {
        var obrasFavoritas = await _service.ObterFavoritosPorUsuario(userId);
        
        if (obrasFavoritas == null)
        {
            await Notify("Ocorreu um erro ao buscar a lista de favoritos");
        }

        return await CustomResponse(obrasFavoritas!);
    }
    
    [HttpPost("{userId:guid}")]
    public async Task<ActionResult> AdicionarFavorito([FromRoute] Guid userId, [FromQuery]string obraId, [FromQuery]ETipoObra tipoObra)
    {
        await _service.AdicionarFavorito(userId, obraId, tipoObra);

        return await CustomResponse();
    }
    
    
    [HttpDelete("{userId:guid}")]
    public async Task<ActionResult> RemoverFavorito([FromRoute] Guid userId, [FromQuery]string obraId)
    {
        await _service.RemoverFavorito(userId, obraId);

        return await CustomResponse();
    }

    // private void ObterUsuario()
    // {
    //     var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    // }
}