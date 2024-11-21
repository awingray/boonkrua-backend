using Boonkrua.Common.Enums;
using Boonkrua.Common.Messages;
using Boonkrua.Http.Services.Notifications;
using Boonkrua.Http.Services.Notifications.Interfaces;

namespace Boonkrua.Http.Factories;

public sealed class NotificationServiceFactory(IServiceProvider provider)
{
    private readonly IServiceProvider _provider = provider;

    public INotificationService GetService(NotificationType type) =>
        type switch
        {
            NotificationType.Discord => _provider.GetRequiredService<DiscordNotificationService>(),
            _ => throw new ArgumentException(NotificationMessages.InvalidProvider, nameof(type)),
        };
}
