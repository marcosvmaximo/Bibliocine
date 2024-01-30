using Bibliocine.Core.Messages;

namespace Bibliocine.Core.Application;

public interface INotifyHandler
{
    Task PublicarNotificacao<T>(T notificacao) where T : Notification;
    Task<bool> AnyNotifications();
    Task<IEnumerable<Notification>> GetNotifications();
}
