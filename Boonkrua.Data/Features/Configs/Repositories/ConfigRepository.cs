using Boonkrua.Data.Contexts;
using Boonkrua.Data.Features.Configs.Interfaces;
using Boonkrua.Data.Features.Configs.Models;
using MongoDB.Driver;

namespace Boonkrua.Data.Features.Configs.Repositories;

public sealed class ConfigRepository(BoonkruaContext context) : IConfigRepository
{
    private readonly IMongoCollection<Config> _col = context.Configs;

    public async Task<Config?> GetByUserIdAsync(string userId) =>
        await _col.Find(c => c.UserId == userId).FirstOrDefaultAsync();

    public async Task CreateAsync(Config config) => await _col.InsertOneAsync(config);
}
