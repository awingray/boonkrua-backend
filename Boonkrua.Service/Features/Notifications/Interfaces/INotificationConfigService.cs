using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Features.Notifications.Interfaces;

public interface INotificationConfigService
{
    Task<Result<NotificationConfigDto, NotificationConfigError>> GetByUserIdAsync(string userId);

    Task<Result<Message, NotificationConfigError>> CreateAsync(NotificationConfigDto dto);

    //TODO: add the rest of cruds, Update, Delete
}
