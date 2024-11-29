using Boonkrua.Data.Models.Topics;
using MongoDB.Driver;

namespace Boonkrua.Data.Contexts;

public sealed class MongoDbContext(IMongoClient client, string dbName)
{
    private readonly IMongoDatabase _db = client.GetDatabase(dbName);

    public IMongoCollection<Topic> Topics => _db.GetCollection<Topic>(nameof(Models.Topics));
}