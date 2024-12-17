using Boonkrua.Api.Features.Notifications.Requests;
using Boonkrua.Service.Features.Configs.Interfaces;
using Boonkrua.Service.Features.Notifications.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Features.Notifications;

internal static class Endpoint
{
    internal static void MapNotificationConfigEndpoints(this WebApplication app)
    {
        app.MapGet(
                Routes.NotificationConfig.GetByUserId,
                [Authorize]
                async (string userId, [FromServices] IConfigService service) =>
                    await Handler.GetByUserId(userId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.NotificationConfig.Create,
                [Authorize]
                async (
                    [FromBody] CreateRequest request,
                    [FromServices] IConfigService service,
                    HttpContext context
                ) => await Handler.Create(request, service, context)
            )
            .RequireAuthorization();
    }
}
