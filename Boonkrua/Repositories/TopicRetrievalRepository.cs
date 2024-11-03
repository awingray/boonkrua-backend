using Boonkrua.Enums;
using Boonkrua.Models;
using MongoDB.Driver;

namespace Boonkrua.Repositories;

internal class TopicRetrievalRepository(IMongoDatabase db) : ITopicRetrievalRepository
{
    private readonly IMongoCollection<Topic> _col = db.GetCollection<Topic>(
        nameof(Collections.Topics)
    );

    public async Task<Topic?> GetTopicById(long id) =>
        await _col.Find(t => t.Id == id).FirstOrDefaultAsync();
}
