using Boonkrua.Api.Features.Notifications.Requests;
using Boonkrua.Service.Features.Notifications.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Features.Notifications;

internal static class NotificationConfigEndpoint
{
    internal static void MapNotificationConfigEndpoints(this WebApplication app)
    {
        app.MapGet(
                Routes.NotificationConfig.GetByUserId,
                [Authorize]
                async (string userId, [FromServices] INotificationConfigService service) =>
                    await NotificationConfigHandler.GetByUserId(userId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.NotificationConfig.Create,
                [Authorize]
                async (
                    [FromBody] CreateNotificationConfigRequest request,
                    [FromServices] INotificationConfigService service,
                    HttpContext context
                ) => await NotificationConfigHandler.Create(request, service, context)
            )
            .RequireAuthorization();
    }
}
