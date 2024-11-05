using Boonkrua.Constants;
using Boonkrua.Models;
using Boonkrua.Models.Data;
using Boonkrua.Models.Dto;
using Boonkrua.Models.Response;
using Boonkrua.Repositories;
using Boonkrua.Repositories.Topics;
using MongoDB.Bson;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(string topicId, ITopicRepository repository) =>
        await repository.GetByIdAsync(topicId) is { } result ? Ok(result) : NotFound();

    internal static async Task<IResult> GetAllTopic(ITopicRepository repository) =>
        Ok(await repository.GetAllAsync());

    internal static async Task<IResult> CreateParentTopic(TopicDto dto, ITopicRepository repository)
    {
        var entity = dto.ToEntity();
        await repository.CreateAsync(entity);
        return Ok(Result<TopicDto>.Create(dto, TopicMessages.CreateParentSuccess));
    }
}
