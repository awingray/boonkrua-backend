using Boonkrua.Data.Features.Notifications.Models;

namespace Boonkrua.Data.Features.Notifications.Interfaces;

public interface INotificationConfigRepository
{
    Task<NotificationConfig?> GetByUserIdAsync(string userId);

    Task CreateAsync(NotificationConfig config);
}
