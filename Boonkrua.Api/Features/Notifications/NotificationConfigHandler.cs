using Boonkrua.Api.Features.Notifications.Requests;
using Boonkrua.Api.Helpers;
using Boonkrua.Service.Features.Notifications.Interfaces;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Api.Features.Notifications;

internal static class NotificationConfigHandler
{
    internal static async Task<IResult> GetByUserId(
        string userId,
        INotificationConfigService service
    )
    {
        var result = await service.GetByUserIdAsync(userId);
        return result.Match(Ok, NotFound);
    }

    internal static async Task<IResult> Create(
        CreateNotificationConfigRequest request,
        INotificationConfigService service,
        HttpContext context
    ) =>
        await UserContextHelper
            .GetUserId(context)
            .Match(
                async userId =>
                {
                    var dto = request.ToDto(userId);
                    var result = await service.CreateAsync(dto);
                    return result.Match(Ok, BadRequest);
                },
                Task.FromResult
            );
}