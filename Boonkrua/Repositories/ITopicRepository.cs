using Boonkrua.Models;

namespace Boonkrua.Repositories;

internal interface ITopicRepository
{
    public Task<Topic?> GetTopicById(long id);
}
