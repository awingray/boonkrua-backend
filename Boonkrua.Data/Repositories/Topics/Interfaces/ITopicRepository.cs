using Boonkrua.Data.Models.Topics;

namespace Boonkrua.Data.Repositories.Topics.Interfaces;

public interface ITopicRepository
{
    public Task<Topic?> GetByIdAsync(string id);
    public Task<IEnumerable<Topic>> GetAllAsync();
    public Task CreateAsync(Topic topic);
    public Task UpdateAsync(Topic topic);
    public Task DeleteAsync(string id);
}
