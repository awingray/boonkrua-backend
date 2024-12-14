using Boonkrua.Data.Contexts;
using Boonkrua.Data.Features.Notifications.Interfaces;
using Boonkrua.Data.Features.Notifications.Models;
using MongoDB.Driver;

namespace Boonkrua.Data.Features.Notifications.Repositories;

public class ConfigRepository(BoonkruaContext context) : IConfigRepository
{
    private readonly IMongoCollection<Config> _col = context.NotificationConfigs;

    public async Task<Config?> GetByUserIdAsync(string userId) =>
        await _col.Find(c => c.UserId == userId).FirstOrDefaultAsync();

    public async Task CreateAsync(Config config) => await _col.InsertOneAsync(config);
}
