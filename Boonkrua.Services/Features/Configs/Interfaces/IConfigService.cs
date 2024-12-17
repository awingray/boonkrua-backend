using Boonkrua.Services.Features.Configs.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Configs.Interfaces;

public interface IConfigService
{
    Task<Result<ConfigDto, ConfigError>> GetByUserIdAsync(string userId);

    Task<Result<string, ConfigError>> GetVendorKeyByTypeAsync(string userId, NotificationType type);

    Task<Result<Message, ConfigError>> CreateAsync(ConfigDto dto);

    //TODO: add the rest of cruds, Update, Delete
}
