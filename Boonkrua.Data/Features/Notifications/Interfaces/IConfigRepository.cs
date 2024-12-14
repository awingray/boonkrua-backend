using Boonkrua.Data.Features.Notifications.Models;

namespace Boonkrua.Data.Features.Notifications.Interfaces;

public interface IConfigRepository
{
    Task<Config?> GetByUserIdAsync(string userId);

    Task CreateAsync(Config config);
}
