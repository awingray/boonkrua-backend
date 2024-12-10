using Boonkrua.Service.Models.Dto;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Interfaces.Notifications;

public interface INotificationConfigService
{
    Task<Result<NotificationConfigDto, NotificationConfigError>> GetByUserIdAsync(string userId);

    Task<Result<Message, NotificationConfigError>> CreateAsync(NotificationConfigDto dto);

    //TODO: add the rest of cruds, Update, Delete
}
