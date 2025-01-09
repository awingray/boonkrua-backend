using Boonkrua.Services.Features.Configs;
using Boonkrua.Services.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Configs.Services;
using Boonkrua.Services.Features.Notifications.Dispatchers;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Orchestrators;
using Boonkrua.Services.Features.Orchestrators.Interfaces;
using Boonkrua.Services.Features.Orchestrators.Services;
using Boonkrua.Services.Features.Topics;
using Boonkrua.Services.Features.Topics.Interfaces;
using Boonkrua.Services.Features.Topics.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITopicNotificationOrchestrator, TopicNotificationOrchestrator>();
        services.AddScoped<INotificationDispatcher, NotificationDispatcher>();
        services.AddScoped<IConfigService, ConfigService>();
    }
}
