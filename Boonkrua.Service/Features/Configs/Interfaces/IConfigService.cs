using Boonkrua.Service.Features.Configs.Models;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Features.Configs.Interfaces;

public interface IConfigService
{
    Task<Result<ConfigDto, ConfigError>> GetByUserIdAsync(string userId);

    Task<Result<Message, ConfigError>> CreateAsync(ConfigDto dto);

    //TODO: add the rest of cruds, Update, Delete
}
