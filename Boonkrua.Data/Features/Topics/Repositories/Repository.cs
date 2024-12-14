using Boonkrua.Data.Contexts;
using Boonkrua.Data.Features.Topics.Interfaces;
using Boonkrua.Data.Features.Topics.Models;
using MongoDB.Driver;

namespace Boonkrua.Data.Features.Topics.Repositories;

public sealed class Repository(BoonkruaContext context) : IRepository
{
    private readonly IMongoCollection<Topic> _col = context.Topics;

    public async Task<Topic?> GetByIdAsync(string id) =>
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
                .Set(t => t.ChildTopics, topic.ChildTopics)
        );

    public async Task DeleteAsync(string id) => await _col.DeleteOneAsync(t => t.Id == id);
}
