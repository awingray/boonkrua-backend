using Boonkrua.DataContracts.Request.Topics;
using Boonkrua.Http.Handlers;
using Boonkrua.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Http.Endpoints;

public static class TopicEndpoints
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
            async ([FromServices] ITopicService service) => await TopicHandler.GetAllTopic(service)
        );

        app.MapPost(
            "/topic",
            async ([FromBody] CreateTopicRequest request, [FromServices] ITopicService service) =>
                await TopicHandler.CreateTopic(request, service)
        );

        app.MapPut(
            "/topic",
            async ([FromBody] UpdateTopicRequest request, [FromServices] ITopicService service) =>
                await TopicHandler.UpdateTopic(request, service)
        );

        app.MapDelete(
            "/topic/{objectId}",
            async (string objectId, [FromServices] ITopicService service) =>
                await TopicHandler.DeleteTopic(objectId, service)
        );

        app.MapPost(
            "/topic/{objectId}/notify/{type}",
            async (
                string objectId,
                string type,
                [FromServices] ITopicNotificationService service
            ) => await TopicHandler.NotifyTopic(objectId, type, service)
        );
    }
}
