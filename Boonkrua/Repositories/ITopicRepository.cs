using Boonkrua.Models;

namespace Boonkrua.Repositories;

public interface ITopicRepository
{
    public Task<Topic?> GetByIdAsync(long id);
    public Task<IEnumerable<Topic>> GetAllAsync();
    public Task CreateAsync(Topic topic);
    public Task UpdateAsync(Topic topic);
    public Task DeleteAsync(long id);
}
