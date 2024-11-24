using Boonkrua.Data.Repositories.Topics;
using Boonkrua.Data.Repositories.Topics.Interfaces;

namespace Boonkrua.Http.Configurations;

internal static partial class ServiceExtensions
{
    internal static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ITopicRepository, TopicRepository>();
    }
}
