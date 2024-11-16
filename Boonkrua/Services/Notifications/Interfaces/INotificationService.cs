using Boonkrua.Models.Error.Notifications;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Notifications.Interfaces;

public interface INotificationService
{
    Task<Result<MessageResponse, NotificationError>> SendNotificationAsync(string message);
}
