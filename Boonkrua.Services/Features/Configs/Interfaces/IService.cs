using Boonkrua.Services.Features.Configs.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Configs.Interfaces;

public interface IService
{
    Task<Result<ConfigDto, ConfigError>> GetByUserIdAsync(string userId);

    Task<Result<Message, ConfigError>> CreateAsync(ConfigDto dto);

    //TODO: add the rest of cruds, Update, Delete
}
