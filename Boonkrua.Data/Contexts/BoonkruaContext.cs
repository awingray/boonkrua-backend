using Boonkrua.Data.Features.Notifications.Models;
using Boonkrua.Data.Features.Topics.Models;
using MongoDB.Driver;

namespace Boonkrua.Data.Contexts;

public sealed class BoonkruaContext(IMongoClient client, string dbName)
{
    private readonly IMongoDatabase _db = client.GetDatabase(dbName);

    public IMongoCollection<Topic> Topics => _db.GetCollection<Topic>(nameof(Topics));

    public IMongoCollection<Config> NotificationConfigs =>
        _db.GetCollection<Config>(nameof(NotificationConfigs));

    public void EnsureIndexes()
    {
        EnsureNotificationConfigsIndexes();
    }

    private void EnsureNotificationConfigsIndexes()
    {
        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexKeys = Builders<Config>.IndexKeys.Ascending(config => config.UserId);
        var indexModel = new CreateIndexModel<Config>(indexKeys, indexOptions);

        NotificationConfigs.Indexes.CreateOne(indexModel);
    }
}
