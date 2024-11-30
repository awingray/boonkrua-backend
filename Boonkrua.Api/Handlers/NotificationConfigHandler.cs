using System.Security.Claims;
using Boonkrua.Api.Payloads.Requests.Notifications;
using Boonkrua.Service.Interfaces.Notifications;
using Boonkrua.Shared.Extensions;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Api.Handlers;

internal static class NotificationConfigHandler
{
    internal static async Task<IResult> GetByUserId(string userId, INotificationConfigService service)
    {
        var result = await service.GetByUserIdAsync(userId);
        return result.Match(Ok, NotFound);
    }

    internal static async Task<IResult> Create(
        CreateNotificationConfigRequest request, 
        INotificationConfigService service, 
        HttpContext context)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId.IsNullOrEmpty())
            return Unauthorized();
        
        var dto = request.ToDto(userId!);
        var result = await service.CreateAsync(dto);

        return result.Match(Ok, BadRequest);
    }
}