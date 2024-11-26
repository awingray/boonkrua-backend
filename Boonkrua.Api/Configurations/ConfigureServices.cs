using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Topics;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.Api.Configurations;

internal static partial class ServiceExtensions
{
    internal static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITopicNotificationService, TopicNotificationService>();
    }
}
