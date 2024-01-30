using Bibliocine.Core.Application;
using Bibliocine.Core.DTO;
using Bibliocine.Core.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bibliocine.API.Controller.Common;

[ApiController]
public abstract class CommonController : ControllerBase
{
    protected readonly INotifyHandler _notifyHandler;
    
    public CommonController(INotifyHandler notifyHandler)
    {
        _notifyHandler = notifyHandler;
    }
      protected async Task<ActionResult> CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            await NotifyModelState(modelState);

        return await CustomResponse();
    }

    protected async Task<ActionResult> CustomResponse(object result = null)
    {
        if (await _notifyHandler.AnyNotifications())
        {
            var notifications = await _notifyHandler.GetNotifications();

            return BadRequest(new BaseResponse
            {
                HttpCode = 400,
                Sucess = false,
                Message = "Ocorreu um erro ao enviar a requisição.",
                Result = _notifyHandler.GetNotifications().Result.Select(x => new { Key = x.Property, Value = x.Message })
            }); ;
        }

        return Ok(new BaseResponse
        {
            HttpCode = 200,
            Sucess = true,
            Message = "Requisição enviada com sucesso.",
            Result = result
        });
    }

    protected async Task NotifyModelState(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);

        foreach (var erro in erros)
        {
            var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            await Notify(erroMsg);
        }
    }

    protected async Task Notify(string message)
    {
        await _notifyHandler.PublicarNotificacao(new Notification(null, message));
    }

    protected async Task Notify(string key, string message)
    {
        await _notifyHandler.PublicarNotificacao(new Notification(key, message));
    }

    [Route("api/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult HandleError()
    {
        return BadRequest(new
        {
            HttpCode = 500,
            Sucess = false,
            Message = "Falha no servidor."
        });
    }
}