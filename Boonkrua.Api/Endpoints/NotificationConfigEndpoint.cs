using Boonkrua.Api.Handlers;
using Boonkrua.Api.Payloads.Requests.Notifications;
using Boonkrua.Service.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiRoutes = Boonkrua.Api.Routes.ApiRoutes;

namespace Boonkrua.Api.Endpoints;

internal static class NotificationConfigEndpoint
{
    internal static void MapNotificationConfigEndpoints(this WebApplication app)
    {
        app.MapGet(
                Routes.ApiRoutes.NotificationConfig.GetByUserId,
                [Authorize]
                async (string userId, [FromServices] INotificationConfigService service) =>
                    await NotificationConfigHandler.GetByUserId(userId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                ApiRoutes.Topic.Create,
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
