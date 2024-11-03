using Boonkrua.Repositories;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(long topicId, ITopicRepository repository) =>
        await repository.GetTopicByIdAsync(topicId) is { } value ? Ok(value) : NotFound();
}
