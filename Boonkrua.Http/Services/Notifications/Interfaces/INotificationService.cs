using Boonkrua.Http.Models.Error.Notifications;
using Boonkrua.Http.Models.Response;

namespace Boonkrua.Http.Services.Notifications.Interfaces;

public interface INotificationService
{
    Task<Result<MessageResponse, NotificationError>> SendNotificationAsync(string message);
}
