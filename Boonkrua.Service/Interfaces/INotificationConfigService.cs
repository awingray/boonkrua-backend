using Boonkrua.Service.Models.Dto.Notification;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Interfaces;

public interface INotificationConfigService
{
    Task<Result<NotificationConfigDto, NotificationConfigError>> GetByUserIdAsync(string userId);

    Task<Result<Message, NotificationError>> CreateAsync(NotificationConfigDto dto);
}
