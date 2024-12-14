using Boonkrua.Data.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Notifications;

public sealed class NotificationConfigService(IConfigRepository repository)
    : INotificationConfigService
{
    private readonly IConfigRepository _repository = repository;

    public async Task<Result<ConfigDto, ConfigError>> GetByUserIdAsync(string userId)
    {
        var config = await _repository.GetByUserIdAsync(userId);
        if (config is null)
            return ConfigError.NotFound;

        return ConfigDto.FromEntity(config);
    }

    public async Task<Result<Message, ConfigError>> CreateAsync(ConfigDto dto)
    {
        var config = await _repository.GetByUserIdAsync(dto.UserId);
        if (config is not null)
            return ConfigError.Duplicate;

        await _repository.CreateAsync(dto.ToEntity());
        return Message.Create(NotificationConfigMessages.Create.Success);
    }
}
