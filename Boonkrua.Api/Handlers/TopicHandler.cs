using System.Security.Claims;
using Boonkrua.Api.Requests.Topics;
using Boonkrua.Service.Interfaces;
using Boonkrua.Shared.Extensions;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Api.Handlers;

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
        ITopicService service,
        HttpContext context
    )
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId.IsNullOrEmpty())
            return Unauthorized();

        var dto = request.ToDto(userId!);
        var result = await service.CreateAsync(dto);
        return result.Match(Ok, BadRequest);
    }

    internal static async Task<IResult> UpdateTopic(
        UpdateTopicRequest request,
        ITopicService service,
        HttpContext context
    )
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId.IsNullOrEmpty())
            return Unauthorized();

        var dto = request.ToDto(userId!);
        var result = await service.UpdateAsync(dto);
        return result.Match(Ok, BadRequest);
    }

    internal static async Task<IResult> DeleteTopic(string objectId, ITopicService service)
    {
        var result = await service.DeleteAsync(objectId);
        return result.Match(Ok, BadRequest);
    }

    internal static async Task<IResult> NotifyTopic(
        string objectId,
        string type,
        ITopicNotificationService service
    )
    {
        var result = await service.NotifyAsync(objectId, type);
        return result.Match(Ok, BadRequest);
    }
}
