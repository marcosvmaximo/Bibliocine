using Bibliocine.API.Controller.Common;
using Bibliocine.Core.Application;
using Bibliocine.Business;
using Bibliocine.Business.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliocine.API.Controller;

[Route("v1/catalogo")]
[Authorize]
public class CatalogoController : CommonController
{
    private readonly IObraService<Obra> _service;
    
    public CatalogoController(
        INotifyHandler notifyHandler,
        IObraService<Obra> service) : base(notifyHandler)
    {
        _service = service;
    }
    
    [HttpGet]
    [AllowAnonymous] 
    public async Task<ActionResult<IEnumerable<Obra>>> Pesquisar([FromQuery] string filtro)
    {
        var obras = await _service.Pesquisar(filtro);

        if (obras == null)
        {
            await Notify("Nenhum filme ou livro encontrado.");
            return await CustomResponse();
        }
        
        return await CustomResponse(obras);
    }
}