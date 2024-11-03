using Boonkrua.Models;

namespace Boonkrua.Repositories;

public interface ITopicRepository
{
    public Task<Topic> GetTopicById(long id);
}
