using Boonkrua.Handlers;
using Boonkrua.Repositories;
using MongoDB.Bson;

namespace Boonkrua.Extensions;

public static class WebApplicationExtensions
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                "/topic/{objectId}",
                async (ObjectId objectId, ITopicRepository repository) =>
                    await TopicHandler.GetTopicById(objectId, repository)
            )
            .WithName("GetTopicById")
            .WithOpenApi();

        app.MapGet(
                "/topic",
                async (ITopicRepository repository) => await TopicHandler.GetAllTopic(repository)
            )
            .WithName("GetAllTopic")
            .WithOpenApi();
    }
}
