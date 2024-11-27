using Boonkrua.Api.Handlers;
using Boonkrua.Api.Requests.Topics;
using Boonkrua.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Endpoints;

public static class TopicEndpoint
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                "/topic/{objectId}",
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await TopicHandler.GetTopicById(objectId, service)
            )
            .RequireAuthorization();

        app.MapGet(
                "/topic",
                [Authorize]
                async ([FromServices] ITopicService service) =>
                    await TopicHandler.GetAllTopic(service)
            )
            .RequireAuthorization();

        app.MapPost(
                "/topic",
                [Authorize]
                async (
                    [FromBody] CreateTopicRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await TopicHandler.CreateTopic(request, service, context)
            )
            .RequireAuthorization();

        app.MapPut(
                "/topic",
                [Authorize]
                async (
                    [FromBody] UpdateTopicRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await TopicHandler.UpdateTopic(request, service, context)
            )
            .RequireAuthorization();

        app.MapDelete(
                "/topic/{objectId}",
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await TopicHandler.DeleteTopic(objectId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                "/topic/{objectId}/notify/{type}",
                [Authorize]
                async (
                    string objectId,
                    string type,
                    [FromServices] ITopicNotificationService service
                ) => await TopicHandler.NotifyTopic(objectId, type, service)
            )
            .RequireAuthorization();
    }
}
