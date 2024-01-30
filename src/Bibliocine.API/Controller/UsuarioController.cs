using System.Security.Claims;
using Bibliocine.API.Controller.Common;
using Bibliocine.Core.Application;
using Bibliocine.Business;
using Bibliocine.Business.Enum;
using Bibliocine.Business.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bibliocine.API.Controller;

[Route("v1/usuario")]
public class UsuarioController : CommonController
{
    private readonly IUsuarioService _service;

    public UsuarioController(INotifyHandler notifyHandler, IUsuarioService service) : base(notifyHandler)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Obra>>> ObterFavoritos()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();

        var obrasFavoritas = await _service.ObterFavoritosPorUsuario(Guid.Parse(userId));
        if (obrasFavoritas == null)
        {
            await Notify("Ocorreu um erro ao buscar a lista de favoritos");
        }

        return await CustomResponse(obrasFavoritas!);
    }
    
    [HttpPost]
    public async Task<ActionResult> AdicionarFavorito([FromQuery]string obraId, [FromQuery]ETipoObra tipoObra)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var result = await _service.AdicionarFavorito(Guid.Parse(userId), obraId, tipoObra);
        if (!result) await Notify("Ocorreu um erro ao adicionar essa obra ao seu favorito.");

        return await CustomResponse();
    }
    //
    //
    // [HttpDelete("{idObra}")]
    // public async Task<ActionResult> RemoverFavorito([FromRoute] string idObra)
    // {
    //     
    // }
}