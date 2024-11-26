using Boonkrua.Service.Models;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Interfaces;

public interface INotificationService
{
    Task<Result<Message, NotificationError>> SendNotificationAsync(NotificationPayload payload);
}
