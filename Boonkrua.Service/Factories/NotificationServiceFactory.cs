using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Notifications;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.Service.Factories;

public sealed class NotificationServiceFactory(IServiceProvider provider)
{
    private readonly IServiceProvider _provider = provider;

    public INotificationService GetService(NotificationType type) =>
        type switch
        {
            NotificationType.Discord => _provider.GetRequiredService<DiscordNotificationService>(),
            NotificationType.Line => _provider.GetRequiredService<LineNotificationService>(),
            _ => throw new ArgumentException(NotificationMessages.InvalidProvider, nameof(type)),
        };
}
