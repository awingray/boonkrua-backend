using Boonkrua.Handlers;
using Boonkrua.Models.Request;
using Boonkrua.Services.Topics;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Extensions;

public static class WebApplicationExtensions
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                "/topic/{objectId}",
                async (string objectId, [FromServices] ITopicService service) =>
                    await TopicHandler.GetTopicById(objectId, service)
            )
            .WithName("GetTopicById")
            .WithOpenApi();

        app.MapGet(
                "/topic",
                async ([FromServices] ITopicService service) =>
                    await TopicHandler.GetAllTopic(service)
            )
            .WithName("GetAllTopic")
            .WithOpenApi();

        app.MapPost(
                "/topic",
                async (
                    [FromBody] CreateTopicRequest request,
                    [FromServices] ITopicService service
                ) => await TopicHandler.CreateTopic(request, service)
            )
            .WithName("CreateTopic")
            .WithOpenApi();

        app.MapPut(
                "/topic",
                async (
                    [FromBody] UpdateTopicRequest request,
                    [FromServices] ITopicService service
                ) => await TopicHandler.UpdateTopic(request, service)
            )
            .WithName("UpdateTopic")
            .WithOpenApi();
    }
}
