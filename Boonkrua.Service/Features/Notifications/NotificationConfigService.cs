using Boonkrua.Data.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Notifications;

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

    public async Task<Result<Message, NotificationConfigError>> CreateAsync(
        NotificationConfigDto dto
    )
    {
        var config = await _repository.GetByUserIdAsync(dto.UserId);
        if (config is not null)
            return NotificationConfigError.Duplicate;

        await _repository.CreateAsync(dto.ToEntity());
        return Message.Create(NotificationConfigMessages.Create.Success);
    }
}
