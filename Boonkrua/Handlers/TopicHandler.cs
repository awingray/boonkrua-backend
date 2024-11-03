using Boonkrua.Models;
using Boonkrua.Models.Data;
using Boonkrua.Models.Dto;
using Boonkrua.Repositories;
using Boonkrua.Repositories.Topics;
using MongoDB.Bson;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(
        ObjectId topicId,
        ITopicRepository repository
    ) => await repository.GetByIdAsync(topicId) is { } result ? Ok(result) : NotFound();

    internal static async Task<IResult> GetAllTopic(ITopicRepository repository) =>
        Ok(await repository.GetAllAsync());

    internal static async Task<IResult> CreateParentTopic(
        ParentTopicDto dto,
        ITopicRepository repository
    )
    {
        var entity = Topic.CreateParent(dto.Title, dto.Description);
        await repository.CreateAsync(entity);
        return Ok(new { Message = "Parent topic has been created", Data = entity });
    }
}
