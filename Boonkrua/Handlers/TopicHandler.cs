using Boonkrua.Models;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

public static class TopicHandler
{
    internal static IResult GetTopicById(long topicId)
    {
        return Ok(Topic.CreateParent(topicId, "Test"));
    }
}
