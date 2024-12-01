using Boonkrua.Api.Handlers;
using Boonkrua.Api.Payloads.Requests.Notifications;
using Boonkrua.Service.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Endpoints;

public static class NotificationConfigEndpoint
{
    public static void MapNotificationConfigEndpoints(this WebApplication app)
    {
        app.MapGet(
                Routes.Routes.NotificationConfig.GetByUserId,
                [Authorize]
                async (string userId, [FromServices] INotificationConfigService service) =>
                    await NotificationConfigHandler.GetByUserId(userId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.Routes.Topic.Create,
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
