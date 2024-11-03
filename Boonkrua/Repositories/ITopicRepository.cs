using Boonkrua.Models;
using MongoDB.Bson;

namespace Boonkrua.Repositories;

public interface ITopicRepository
{
    public Task<Topic?> GetByIdAsync(ObjectId id);
    public Task<IEnumerable<Topic>> GetAllAsync();
    public Task CreateAsync(Topic topic);
    public Task UpdateAsync(Topic topic);
    public Task DeleteAsync(ObjectId id);
}
