using Boonkrua.Models.Data;
using MongoDB.Bson;

namespace Boonkrua.Repositories.Topics;

public interface ITopicRepository
{
    public Task<Topic?> GetByIdAsync(string id);
    public Task<IEnumerable<Topic>> GetAllAsync();
    public Task CreateAsync(Topic topic);
    public Task UpdateAsync(Topic topic);
    public Task DeleteAsync(string id);
}
