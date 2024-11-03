using Boonkrua.Models;
using Boonkrua.Repositories;
using MongoDB.Driver;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(long topicId, ITopicRepository repository)
    {
        var topic = await repository.GetTopicById(topicId);
        return topic is null ? NotFound() : Ok(topic);
    }
}
