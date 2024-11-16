using Boonkrua.Models.Error;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Notification;

public interface INotificationService
{
    Task<Result<MessageResponse, NotificationError>> SendNotificationAsync(string message);
}
