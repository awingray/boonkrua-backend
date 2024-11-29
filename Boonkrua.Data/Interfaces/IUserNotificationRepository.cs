using Boonkrua.Data.Models.Notifications;

namespace Boonkrua.Data.Interfaces;

public interface IUserNotificationRepository
{
    Task<UserNotificationConfig?> GetByUserIdAsync(string userId);

    Task CreateAsync(UserNotificationConfig config);
}
