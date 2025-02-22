using Boonkrua.Api.Features.Topics.Mappers;
using Boonkrua.Api.Features.Topics.Requests;
using Boonkrua.Api.Helpers;
using Boonkrua.Services.Features.Orchestrators.Interfaces;
using Boonkrua.Services.Features.Topics.Interfaces;
using Boonkrua.Shared.Extensions;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Api.Features.Topics;

internal static class Handler
{
    internal static async Task<IResult> GetById(string topicId, ITopicService service)
    {
        var result = await service.GetByIdAsync(topicId);
        return result.Match(r => Ok(TopicResponseMapper.FromDto(r)), NotFound);
    }

    internal static async Task<IResult> GetAll(ITopicService service)
    {
        var result = await service.GetAllAsync();
        return result.Match((r) => Ok(r.ToMappedList(TopicResponseMapper.FromDto)), NotFound);
    }

    internal static async Task<IResult> Create(
        TopicCreateRequest request,
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
        TopicUpdateRequest request,
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
        ITopicNotificationOrchestrator service
    )
    {
        var result = await service.NotifyAsync(objectId, type);
        return result.Match(Ok, BadRequest);
    }
}
