using Boonkrua.Data.Models.Notifications;

namespace Boonkrua.Data.Interfaces;

public interface IUserNotificationRepository
{
    Task<UserNotificationConfig?> GetById(string userId);

    Task Create(UserNotificationConfig config);
}
