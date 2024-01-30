using Bibliocine.Business.Entities;
using Bibliocine.Business.Enum;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.Business.ViewModels;
using Bibliocine.Core.Application;
using Bibliocine.Core.Messages;

namespace Bibliocine.Business.Services;

public class FavoritoService : IFavoritoService
{
    private readonly IUsuarioRepository _repository;
    private readonly INotifyHandler _notifyHandler;
    private readonly IObraService<Obra> _obraService;

    public FavoritoService(
        INotifyHandler notifyHandler,
        IUsuarioRepository repository,
        IObraService<Obra> obraService)
    {
        _notifyHandler = notifyHandler;
        _repository = repository;
        _obraService = obraService;
    }

    public async Task AdicionarFavorito(Guid userId, string obraId, ETipoObra tipoObra)
    {
        var usuario = await ObterUsuario(userId);

        // Regra para limitar o numero de favoritos
        if (usuario.Favoritos.Count > 30)
        {
            await _notifyHandler.PublicarNotificacao(new Notification(usuario.Nome, "Número maximo de favoritos atingido"));
            return;
        }
        
        Favorito favorito = new(usuario, usuario.Id, tipoObra, obraId);
        usuario.AdicionarFavorito(favorito);

        await _repository.Atualizar(usuario);
        await _repository.AdicionarFavorito(favorito);
        
        await _repository.UnityOfWork.Commit();
    }

    public async Task<IEnumerable<Obra>> ObterFavoritosPorUsuario(Guid userId)
    {
        var usuario = await ObterUsuario(userId);

        var result = new List<Obra>();
        
        // Numero de obras limitado à 30, ainda assim não é uma boa esse loop (alternativa: redis, cache, db interno)
        foreach (var favorito in usuario.Favoritos)
        {
            var obra = await _obraService.ObterPorId(favorito.ObraId, favorito.TipoObra);
            result.Add(obra);
        }

        return result;
    }

    public async Task RemoverFavorito(Guid userId, string obraId)
    {
        var usuario = await ObterUsuario(userId);

        var favorito = usuario.Favoritos.FirstOrDefault(x => x.ObraId == obraId);
        if (favorito == null)
        {
            await _notifyHandler.PublicarNotificacao(new Notification(obraId, "Favorito não encontrado para esse usuário."));
            return;
        }

        usuario.RemoverFavorito(favorito);

        await _repository.Atualizar(usuario);
        await _repository.DeletarFavorito(favorito);
        
        await _repository.UnityOfWork.Commit();
    }

    private async Task<Usuario> ObterUsuario(Guid id)
    {
        var usuario = await _repository.ObterPorId(id);
        
        if (usuario == null)
        {
            await _notifyHandler.PublicarNotificacao(new Notification(id.ToString(), "Usuário não encontrado."));
            return null;
        }

        return usuario;
    }
}
