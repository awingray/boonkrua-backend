using Boonkrua.Handlers;
using Boonkrua.Repositories;

namespace Boonkrua.Extensions;

public static class WebApplicationExtensions
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                "/topic/{id:long}",
                async (long id, ITopicRepository repository) =>
                    await TopicHandler.GetTopicById(id, repository)
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
