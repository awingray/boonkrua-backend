using Boonkrua.Models.Dto;
using Boonkrua.Models.Request;
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

    internal static async Task<IResult> CreateParentTopic(
        CreateTopicRequest request,
        ITopicService service
    )
    {
        var dto = TopicDto.FromRequest(request);
        var result = await service.CreateAsync(dto);
        return result.Match(Ok, BadRequest);
    }
}
