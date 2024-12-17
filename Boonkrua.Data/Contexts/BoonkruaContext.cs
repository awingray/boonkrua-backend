using Boonkrua.Data.Features.Notifications.Models;
using Boonkrua.Data.Features.Topics.Models;
using MongoDB.Driver;

namespace Boonkrua.Data.Contexts;

public sealed class BoonkruaContext
{
    private readonly IMongoCollection<Topic> _topics;
    private readonly IMongoCollection<Config> _configs;

    public BoonkruaContext(IMongoClient client, string dbName)
    {
        var db = client.GetDatabase(dbName);
        _topics = db.GetCollection<Topic>(nameof(Topics));
        _configs = db.GetCollection<Config>(nameof(Configs));
    }

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
