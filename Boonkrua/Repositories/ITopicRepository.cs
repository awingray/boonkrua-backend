using Boonkrua.Models;

namespace Boonkrua.Repositories;

public interface ITopicRepository
{
    public Task<Topic?> GetTopicByIdAsync(long id);
    public Task CreateTopicAsync(Topic topic);
    public Task DeleteTopicAsync(long id);
}
