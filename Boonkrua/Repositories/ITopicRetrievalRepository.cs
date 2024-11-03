using Boonkrua.Models;

namespace Boonkrua.Repositories;

internal interface ITopicRetrievalRepository
{
    public Task<Topic?> GetTopicById(long id);
}
