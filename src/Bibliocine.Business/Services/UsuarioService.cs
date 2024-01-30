using Bibliocine.Business.Entities;
using Bibliocine.Business.Enum;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.Business.ViewModels;
using Bibliocine.Core.Application;
using Bibliocine.Core.Messages;

namespace Bibliocine.Business.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly INotifyHandler _notifyHandler;
    private readonly IObraService<Obra> _obraService;

    public UsuarioService(
        INotifyHandler notifyHandler,
        IUsuarioRepository repository,
        IObraService<Obra> obraService)
    {
        _notifyHandler = notifyHandler;
        _repository = repository;
        _obraService = obraService;
    }
    
    public async Task RegistrarUsuario(RegistrarUsuarioViewModel model)
    {
        var usuario = new Usuario(model.Nome, model.DataNascimento, model.Email);

        await _repository.Salvar(usuario);
    }

    public async Task<bool> AdicionarFavorito(Guid userId, string obraId, ETipoObra tipoObra)
    {
        var usuario = await _repository.ObterPorId(userId);
        // Valida se usuário existe
        if (usuario == null)
        {
            await _notifyHandler.PublicarNotificacao(new Notification(userId.ToString(), "Usuário não encontrado."));
            return false;
        }

        // Regra para limitar o numero de favoritos
        if (usuario.Favoritos.Count > 30)
        {
            await _notifyHandler.PublicarNotificacao(new Notification(usuario.Nome, "Número maximo de favoritos atingido"));
            return false;
        }
        
        Favorito favorito = new(usuario, usuario.Id, tipoObra, obraId);
        
        usuario.AdicionarFavorito(favorito);
        await _repository.Salvar(usuario);
        // Save
        
        return true;
    }

    public async Task<IEnumerable<Obra>> ObterFavoritosPorUsuario(Guid userId)
    {
        var usuario = await _repository.ObterPorId(userId);
        if (usuario == null)
        {
            await _notifyHandler.PublicarNotificacao(new Notification(userId.ToString(), "Usuário não encontrado."));
            return null;
        }

        var result = new List<Obra>();
        
        // Numero de obras limitado à 30, ainda assim não é uma boa esse loop (alternativa: redis, cache, db interno)
        foreach (var favorito in usuario.Favoritos)
        {
            var obra = await _obraService.ObterPorId(favorito.ObraId, favorito.TipoObra);
            result.Add(obra);
        }

        return result;
    }
}
