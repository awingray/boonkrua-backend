using Boonkrua.Data.Interfaces;
using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Models.Dto.Notification;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Notifications;

public sealed class NotificationConfigService(INotificationConfigRepository repository)
    : INotificationConfigService
{
    private readonly INotificationConfigRepository _repository = repository;

    public Task<Result<NotificationConfigDto, NotificationConfigError>> GetByUserIdAsync(
        string userId
    )
    {
        throw new NotImplementedException();
    }

    public Task<Result<Message, NotificationError>> CreateAsync(NotificationConfigDto dto)
    {
        throw new NotImplementedException();
    }
}
