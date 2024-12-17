using Boonkrua.Services.Features.Notifications.Factories;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Notifications.Dispatchers;

public sealed class NotificationDispatcher(NotificationServiceFactory serviceFactory)
    : INotificationDispatcher
{
    private readonly NotificationServiceFactory _serviceFactory = serviceFactory;

    public async Task<Result<Message, NotificationError>> DispatchAsync(
        NotificationType type,
        NotificationPayload payload
    )
    {
        var notificationService = _serviceFactory.GetService(type);
        return await notificationService.SendNotificationAsync(payload);
    }
}
