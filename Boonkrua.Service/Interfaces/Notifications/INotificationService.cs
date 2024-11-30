using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Service.Models.Payload;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Interfaces.Notifications;

public interface INotificationService
{
    Task<Result<Message, NotificationError>> SendNotificationAsync(NotificationPayload payload);
}
