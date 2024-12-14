using Boonkrua.Service.Features.Notifications;
using Boonkrua.Service.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Topics;
using Boonkrua.Service.Features.Topics.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITopicNotificationService, TopicNotificationService>();
        services.AddScoped<IConfigService, ConfigService>();
    }
}
