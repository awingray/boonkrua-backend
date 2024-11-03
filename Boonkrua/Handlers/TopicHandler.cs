using Boonkrua.Models;
using Boonkrua.Repositories;
using MongoDB.Driver;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

public static class TopicHandler
{
    internal static IResult GetTopicById(long topicId, ITopicRepository repository)
    {
        return Ok();
    }
}
