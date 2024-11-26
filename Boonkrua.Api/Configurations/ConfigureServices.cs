using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Topics;

namespace Boonkrua.Api.Configurations;

internal static partial class ServiceExtensions
{
    internal static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITopicNotificationService, TopicNotificationService>();
    }
}
