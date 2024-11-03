using Boonkrua.Models;
using Boonkrua.Repositories;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(long topicId, ITopicRepository repository) =>
        await repository.GetByIdAsync(topicId) is { } result ? Ok(result) : NotFound();

    internal static async Task<IResult> GetAllTopic(ITopicRepository repository) =>
        Ok(await repository.GetAllAsync());

    internal static async Task<IResult> CreateParentTopic(
        ParentTopicDto dto,
        ITopicRepository repository
    )
    {
        return Ok();
    }
}
