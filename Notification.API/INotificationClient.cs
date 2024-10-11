namespace Notification.API
{
    public interface INotificationClient
    {
        Task ReceiveNotification(string message);
    }
}
