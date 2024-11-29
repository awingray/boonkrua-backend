using Boonkrua.Api.Handlers;
using Boonkrua.Api.Payloads.Requests.Topics;
using Boonkrua.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Endpoints;

public static class TopicEndpoint
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                Routes.Topic.GetById,
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await TopicHandler.GetTopicById(objectId, service)
            )
            .RequireAuthorization();

        app.MapGet(
                Routes.Topic.GetAll,
                [Authorize]
                async ([FromServices] ITopicService service) =>
                    await TopicHandler.GetAllTopic(service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.Topic.Create,
                [Authorize]
                async (
                    [FromBody] CreateTopicRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await TopicHandler.CreateTopic(request, service, context)
            )
            .RequireAuthorization();

        app.MapPut(
                Routes.Topic.Update,
                [Authorize]
                async (
                    [FromBody] UpdateTopicRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await TopicHandler.UpdateTopic(request, service, context)
            )
            .RequireAuthorization();

        app.MapDelete(
                Routes.Topic.Delete,
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await TopicHandler.DeleteTopic(objectId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.Topic.Notify,
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
