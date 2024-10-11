
using Microsoft.AspNetCore.SignalR;

namespace Notification.API
{
    public class ServerTimeNotifier: BackgroundService
    {
        private static readonly TimeSpan period = TimeSpan.FromSeconds(5);
        private readonly ILogger<ServerTimeNotifier> _logger;
        private readonly IHubContext<NotificationHub, INotificationClient> _context;

        public ServerTimeNotifier(ILogger<ServerTimeNotifier> logger, IHubContext<NotificationHub, INotificationClient> context)
        {
            _logger = logger;
            _context = context;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(period);
            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
                var datetime = DateTime.Now;

                _logger.LogInformation($"Server time {datetime}");

                //await _context.Clients.All.ReceiveNotification($"Server time {datetime}");
                await _context.Clients
                    .User("92c86c72-fefb-4772-8497-0df3d0b19074")
                    .ReceiveNotification($"Server time {datetime}");

            }
        }
    }
}
