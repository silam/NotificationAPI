using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Notification.API
{
    [Authorize]
    public class NotificationHub: Hub<INotificationClient>
    {
        public override async Task OnConnectedAsync()
        {
             await Clients.Client(Context.ConnectionId).ReceiveNotification($"Hello from Server {Context.User?.Identity?.Name}");
             await base.OnConnectedAsync();
        }
    }

      
}
