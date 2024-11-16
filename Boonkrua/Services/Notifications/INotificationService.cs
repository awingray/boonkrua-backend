using Boonkrua.Models.Error;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Notifications;

public interface INotificationService
{
    Task<Result<MessageResponse, NotificationError>> SendNotificationAsync(string message);
}
