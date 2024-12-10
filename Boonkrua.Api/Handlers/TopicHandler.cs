using Boonkrua.Api.Helpers;
using Boonkrua.Api.Payloads.Requests.Topics;
using Boonkrua.Api.Payloads.Responses.Topics;
using Boonkrua.Service.Features.Topics.Interfaces;
using Boonkrua.Shared.Extensions;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Api.Handlers;

internal static class TopicHandler
{
    internal static async Task<IResult> GetById(string topicId, ITopicService service)
    {
        var result = await service.GetByIdAsync(topicId);
        return result.Match(r => Ok(TopicResponse.FromDto(r)), NotFound);
    }

    internal static async Task<IResult> GetAll(ITopicService service)
    {
        var result = await service.GetAllAsync();
        return result.Match((r) => Ok(r.ToMappedList(TopicResponse.FromDto)), NotFound);
    }

    internal static async Task<IResult> Create(
        CreateTopicRequest request,
        ITopicService service,
        HttpContext context
    ) =>
        await UserContextHelper
            .GetUserId(context)
            .Match(
                async userId =>
                {
                    var dto = request.ToDto(userId!);
                    var result = await service.CreateAsync(dto);

                    return result.Match(Ok, BadRequest);
                },
                Task.FromResult
            );

    internal static async Task<IResult> Update(
        UpdateTopicRequest request,
        ITopicService service,
        HttpContext context
    ) =>
        await UserContextHelper
            .GetUserId(context)
            .Match(
                async userId =>
                {
                    var dto = request.ToDto(userId!);
                    var result = await service.UpdateAsync(dto);

                    return result.Match(Ok, BadRequest);
                },
                Task.FromResult
            );

    internal static async Task<IResult> Delete(string objectId, ITopicService service)
    {
        var result = await service.DeleteAsync(objectId);
        return result.Match(Ok, BadRequest);
    }

    internal static async Task<IResult> Notify(
        string objectId,
        string type,
        ITopicNotificationService service
    )
    {
        var result = await service.NotifyAsync(objectId, type);
        return result.Match(Ok, BadRequest);
    }
}
