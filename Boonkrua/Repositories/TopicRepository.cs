using Boonkrua.Enums;
using Boonkrua.Models;
using MongoDB.Driver;

namespace Boonkrua.Repositories;

public sealed class TopicRepository(IMongoDatabase db) : ITopicRepository
{
    private readonly IMongoCollection<Topic> _col = db.GetCollection<Topic>(
        nameof(Collections.Topics)
    );

    public async Task<Topic?> GetTopicByIdAsync(long id) =>
        await _col.Find(t => t.Id == id).FirstOrDefaultAsync();

    public async Task CreateTopicAsync(Topic topic) => await _col.InsertOneAsync(topic);

    public async Task DeleteTopicAsync(long id) => await _col.DeleteOneAsync(t => t.Id == id);
}
