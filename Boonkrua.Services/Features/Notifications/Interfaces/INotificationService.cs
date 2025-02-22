using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Notifications.Interfaces;

public interface INotificationService
{
    NotificationType Type { get; }
    Task<Result<Message, NotificationError>> SendNotificationAsync(NotificationPayload payload);
}
