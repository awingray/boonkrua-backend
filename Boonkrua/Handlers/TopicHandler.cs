using Boonkrua.Models.Dto;
using Boonkrua.Models.Dto.Topics;
using Boonkrua.Models.Request;
using Boonkrua.Models.Request.Topics;
using Boonkrua.Services.Topics;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetTopicById(string topicId, ITopicService service) =>
        (await service.GetByIdAsync(topicId)).Match(Ok, NotFound);

    internal static async Task<IResult> GetAllTopic(ITopicService service)
    {
        var result = await service.GetAllAsync();
        return result.Match(Ok, NotFound);
    }

    internal static async Task<IResult> CreateTopic(
        CreateTopicRequest request,
        ITopicService service
    )
    {
        var dto = TopicDto.FromRequest(request);
        var result = await service.CreateAsync(dto);
        return result.Match(Ok, BadRequest);
    }

    internal static async Task<IResult> UpdateTopic(
        UpdateTopicRequest request,
        ITopicService service
    )
    {
        var dto = TopicDto.FromRequest(request);
        var result = await service.UpdateAsync(dto);
        return result.Match(Ok, BadRequest);
    }

    internal static async Task<IResult> DeleteTopic(string objectId, ITopicService service)
    {
        var result = await service.DeleteAsync(objectId);
        return result.Match(Ok, BadRequest);
    }
}
