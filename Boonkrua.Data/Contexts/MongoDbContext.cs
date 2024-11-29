using Boonkrua.Data.Models.Notifications;
using Boonkrua.Data.Models.Topics;
using MongoDB.Driver;

namespace Boonkrua.Data.Contexts;

public sealed class MongoDbContext(IMongoClient client, string dbName)
{
    private readonly IMongoDatabase _db = client.GetDatabase(dbName);

    public IMongoCollection<Topic> Topics => _db.GetCollection<Topic>(nameof(Topics));

    public IMongoCollection<NotificationConfig> NotificationConfigs =>
        _db.GetCollection<NotificationConfig>(nameof(NotificationConfigs));
}
