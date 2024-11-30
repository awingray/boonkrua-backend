using Boonkrua.Service.Models.Dto;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Interfaces.Notifications;

public interface INotificationConfigService
{
    Task<Result<NotificationConfigDto, NotificationConfigError>> GetByUserIdAsync(string userId);

    Task<Result<Message, NotificationError>> CreateAsync(NotificationConfigDto dto);
}
