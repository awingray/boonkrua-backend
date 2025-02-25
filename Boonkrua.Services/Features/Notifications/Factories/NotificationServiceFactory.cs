using System.Collections.Immutable;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Messages;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Notifications.Factories;

public sealed class NotificationServiceFactory(IEnumerable<INotificationService> services)
    : INotificationServiceFactory
{
    private readonly ImmutableDictionary<NotificationType, INotificationService> _services =
        services.ToImmutableDictionary(s => s.Type, s => s);

    public INotificationService GetService(NotificationType type)
    {
        if (_services.TryGetValue(type, out var service))
            return service;

        throw new ArgumentException(NotificationMessages.Invalid.Provider, nameof(type));
    }
}
