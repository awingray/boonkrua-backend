using Boonkrua.Data.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Configs.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;
using static Boonkrua.Shared.Messages.ConfigMessages;

namespace Boonkrua.Services.Features.Configs;

public sealed class ConfigService(IConfigRepository repository) : IConfigService
{
    private readonly IConfigRepository _repository = repository;

    public async Task<Result<ConfigDto, ConfigError>> GetByUserIdAsync(string userId)
    {
        var config = await _repository.GetByUserIdAsync(userId);
        if (config is null)
            return ConfigError.NotFound;

        return ConfigDto.FromEntity(config);
    }

    public async Task<Result<Message, ConfigError>> GetVendorKeyByTypeAsync(
        string userId,
        NotificationType type
    )
    {
        var userConfigs = await _repository.GetByUserIdAsync(userId);
        if (userConfigs is null)
            return ConfigError.NotFound;

        var vendorConfig = userConfigs.GetKeyByType(type);
        if (vendorConfig is null)
            return ConfigError.NotFoundUser;

        return vendorConfig.AsMessage();
    }

    public async Task<Result<Message, ConfigError>> CreateAsync(ConfigDto dto)
    {
        var config = await _repository.GetByUserIdAsync(dto.UserId);
        if (config is not null)
            return ConfigError.Duplicate;

        await _repository.CreateAsync(dto.ToEntity());
        return Create.Success;
    }
}
