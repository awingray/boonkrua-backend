using Boonkrua.Api.Features.Topics.Requests;
using Boonkrua.Services.Features.Topics.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Features.Topics;

internal static class Endpoint
{
    internal static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                Routes.Topic.GetById,
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await Handler.GetById(objectId, service)
            )
            .RequireAuthorization();

        app.MapGet(
                Routes.Topic.GetAll,
                [Authorize]
                async ([FromServices] ITopicService service) => await Handler.GetAll(service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.Topic.Create,
                [Authorize]
                async (
                    [FromBody] TopicCreateRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await Handler.Create(request, service, context)
            )
            .RequireAuthorization();

        app.MapPut(
                Routes.Topic.Update,
                [Authorize]
                async (
                    [FromBody] TopicUpdateRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await Handler.Update(request, service, context)
            )
            .RequireAuthorization();

        app.MapDelete(
                Routes.Topic.Delete,
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await Handler.Delete(objectId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.Topic.Notify,
                [Authorize]
                async (
                    string objectId,
                    string type,
                    [FromServices] ITopicNotificationService service
                ) => await Handler.Notify(objectId, type, service)
            )
            .RequireAuthorization();
    }
}
