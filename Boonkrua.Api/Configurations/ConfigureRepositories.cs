using Boonkrua.Data.Interfaces;
using Boonkrua.Data.Repositories.Topics;

namespace Boonkrua.Api.Configurations;

internal static partial class ServiceExtensions
{
    internal static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ITopicRepository, TopicRepository>();
    }
}
