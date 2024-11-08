using Boonkrua.Constants;
using Boonkrua.Extensions;
using Boonkrua.Models;
using Boonkrua.Models.Data;
using Boonkrua.Models.Dto;
using Boonkrua.Models.Request;
using Boonkrua.Models.Response;
using Boonkrua.Repositories;
using Boonkrua.Repositories.Topics;
using MongoDB.Bson;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(string topicId, ITopicRepository repository) =>
        await repository.GetByIdAsync(topicId) is { } result
            ? Ok(Result<TopicDto, string>.Ok(TopicDto.FromEntity(result)))
            : NotFound();

    internal static async Task<IResult> GetAllTopic(ITopicRepository repository)
    {
        var topicEntities = await repository.GetAllAsync();
        return Ok(
            Result<IEnumerable<TopicDto>, string>.Ok(
                topicEntities.ToMappedList(TopicDto.FromEntity)
            )
        );
    }

    internal static async Task<IResult> CreateParentTopic(
        CreateTopicRequest request,
        ITopicRepository repository
    )
    {
        var dto = TopicDto.FromRequest(request);
        await repository.CreateAsync(dto.ToEntity());
        return Ok(Result<string, string>.Ok(TopicMessages.CreateParentSuccess));
    }
}
