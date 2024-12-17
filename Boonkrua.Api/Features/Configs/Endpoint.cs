using Boonkrua.Api.Features.Configs.Requests;
using Boonkrua.Services.Features.Configs.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Features.Configs;

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
