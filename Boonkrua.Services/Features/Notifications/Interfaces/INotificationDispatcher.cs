using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Notifications.Interfaces;

public interface INotificationDispatcher
{
    Task<Result<Message, NotificationError>> DispatchAsync(
        NotificationType type,
        NotificationPayload payload
    );
}
