using Bibliocine.Core.Messages;

namespace Bibliocine.Core.Application;

public class NotifyHandler : INotifyHandler
{
    private List<Notification> _notifications;

    public NotifyHandler()
    {
        _notifications = new List<Notification>();
    }

    public async Task PublicarNotificacao<T>(T notificacao) where T : Notification
    {
        _notifications.Add(notificacao);
    }

    public async Task<bool> AnyNotifications()
    {
        return _notifications.Any();
    }

    public async Task<IEnumerable<Notification>> GetNotifications()
    {
        return _notifications;
    }
}