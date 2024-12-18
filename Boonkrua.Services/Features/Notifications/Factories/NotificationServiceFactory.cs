using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Messages;
using Boonkrua.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.Services.Features.Notifications.Factories;

public sealed class NotificationServiceFactory(IServiceProvider provider)
{
    private readonly IServiceProvider _provider = provider;

    public INotificationService GetService(NotificationType type) =>
        type switch
        {
            NotificationType.Discord => _provider.GetRequiredService<DiscordService>(),
            NotificationType.Line => _provider.GetRequiredService<LineService>(),
            _ => throw new ArgumentException(NotificationMessages.Invalid.Provider, nameof(type)),
        };
}
