using Boonkrua.Repositories;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(
        long topicId,
        ITopicRetrievalRepository repository
    )
    {
        var topic = await repository.GetTopicById(topicId);
        return topic is null ? NotFound() : Ok(topic);
    }
}
