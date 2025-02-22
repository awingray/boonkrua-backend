using Boonkrua.Data.Features.Configs.Models;
using Boonkrua.Data.Features.Topics.Models;
using Boonkrua.Data.Interfaces;
using MongoDB.Driver;

namespace Boonkrua.Data.Contexts;

public sealed class BoonkruaContext(IMongoDatabase db) : IBoonkruaContext
{
    private readonly IMongoCollection<Topic> _topics = db.GetCollection<Topic>(nameof(Topics));
    private readonly IMongoCollection<Config> _configs = db.GetCollection<Config>(nameof(Configs));

    public IMongoCollection<Topic> Topics => _topics;
    public IMongoCollection<Config> Configs => _configs;

    public void EnsureIndexes()
    {
        EnsureNotificationConfigsIndexes();
    }

    private void EnsureNotificationConfigsIndexes()
    {
        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexKeys = Builders<Config>.IndexKeys.Ascending(config => config.UserId);
        var indexModel = new CreateIndexModel<Config>(indexKeys, indexOptions);

        _configs.Indexes.CreateOne(indexModel);
    }
}
