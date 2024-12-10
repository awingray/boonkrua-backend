using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Features.Notifications.Interfaces;

public interface INotificationService
{
    Task<Result<Message, NotificationError>> SendNotificationAsync(NotificationPayload payload);
}
