using Boonkrua.Data.Features.Configs.Models;

namespace Boonkrua.Data.Features.Configs.Interfaces;

public interface IConfigRepository
{
    Task<Config?> GetByUserIdAsync(string userId);

    Task CreateAsync(Config config);
}
