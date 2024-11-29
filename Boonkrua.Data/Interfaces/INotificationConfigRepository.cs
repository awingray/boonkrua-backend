using Boonkrua.Data.Models.Notifications;

namespace Boonkrua.Data.Interfaces;

public interface INotificationConfigRepository
{
    Task<NotificationConfig?> GetByUserIdAsync(string userId);

    Task CreateAsync(NotificationConfig config);
}
