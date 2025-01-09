using Boonkrua.Data.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Configs.Mappers;
using Boonkrua.Services.Features.Configs.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using static Boonkrua.Services.Features.Configs.Messages.ConfigMessages;
using Error = Boonkrua.Services.Features.Configs.Models.ConfigError;

namespace Boonkrua.Services.Features.Configs.Services;

public sealed class ConfigService(IConfigRepository repository) : IConfigService
{
    private readonly IConfigRepository _repository = repository;

    public async Task<Result<ConfigDto, Error>> GetByUserIdAsync(string userId)
    {
        var config = await _repository.GetByUserIdAsync(userId);
        if (config is null)
            return Error.NotFound;

        return ConfigDtoMapper.FromEntity(config);
    }

    public async Task<Result<string, Error>> GetVendorKeyByTypeAsync(
        string userId,
        NotificationType type
    )
    {
        var userConfigs = await _repository.GetByUserIdAsync(userId);
        if (userConfigs is null)
            return Error.NotFound;

        var vendorConfig = userConfigs.GetKeyByType(type);
        if (vendorConfig is null)
            return Error.NotFoundUser;

        return vendorConfig;
    }

    public async Task<Result<Message, Error>> CreateAsync(ConfigDto dto)
    {
        var config = await _repository.GetByUserIdAsync(dto.UserId);
        if (config is not null)
            return Error.Duplicate;

        await _repository.CreateAsync(dto.ToEntity());
        return Create.Success;
    }
}
