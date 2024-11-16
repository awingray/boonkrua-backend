using Boonkrua.Constants;
using Boonkrua.Enums;
using Boonkrua.Services.Notifications;

namespace Boonkrua.Factories;

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
