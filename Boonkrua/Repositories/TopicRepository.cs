using Boonkrua.Enums;
using Boonkrua.Models;
using Boonkrua.Models.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Boonkrua.Repositories;

public sealed class TopicRepository(IMongoDatabase db) : ITopicRepository
{
    private readonly IMongoCollection<Topic> _col = db.GetCollection<Topic>(
        nameof(Collections.Topics)
    );

    public async Task<Topic?> GetByIdAsync(ObjectId id) =>
        await _col.Find(t => t.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Topic>> GetAllAsync() =>
        await (await _col.FindAsync(FilterDefinition<Topic>.Empty)).ToListAsync() ?? [];

    public async Task CreateAsync(Topic topic) => await _col.InsertOneAsync(topic);

    public async Task UpdateAsync(Topic topic) =>
        await _col.UpdateOneAsync(
            t => t.Id == topic.Id,
            Builders<Topic>
                .Update.Set(t => t.Title, topic.Title)
                .Set(t => t.Description, topic.Description)
                .Set(t => t.ParentTopic, topic.ParentTopic)
                .Set(t => t.ChildTopics, topic.ChildTopics)
        );

    public async Task DeleteAsync(ObjectId id) => await _col.DeleteOneAsync(t => t.Id == id);
}
