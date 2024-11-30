using Boonkrua.Data.Interfaces;
using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Interfaces.Notifications;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Notifications;

public sealed class NotificationConfigService(INotificationConfigRepository repository)
    : INotificationConfigService
{
    private readonly INotificationConfigRepository _repository = repository;

    public async Task<Result<NotificationConfigDto, NotificationConfigError>> GetByUserIdAsync(
        string userId
    )
    {
        var config = await _repository.GetByUserIdAsync(userId);
        if (config is null)
            return NotificationConfigError.NotFound;

        return NotificationConfigDto.FromEntity(config);
    }

    public async Task<Result<Message, NotificationError>> CreateAsync(NotificationConfigDto dto)
    {
        await _repository.CreateAsync(dto.ToEntity());
        return Message.Create(NotificationMessages.ConfigCreateSuccess);
    }
}
