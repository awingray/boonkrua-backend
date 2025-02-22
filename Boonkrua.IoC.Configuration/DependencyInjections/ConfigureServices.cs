using Boonkrua.Services.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Configs.Services;
using Boonkrua.Services.Features.Notifications.Dispatchers;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Services;
using Boonkrua.Services.Features.Orchestrators.Interfaces;
using Boonkrua.Services.Features.Orchestrators.Services;
using Boonkrua.Services.Features.Topics.Interfaces;
using Boonkrua.Services.Features.Topics.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.ConfigureNotificationServices();
        services.ConfigureTopicServices();
        services.ConfigureConfigServices();
        services.ConfigureOrchestratorServices();
    }

    private static void ConfigureNotificationServices(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, LineService>();
        services.AddScoped<INotificationService, DiscordService>();
        services.AddScoped<INotificationDispatcher, NotificationDispatcher>();
    }

    private static void ConfigureTopicServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
    }

    private static void ConfigureConfigServices(this IServiceCollection services)
    {
        services.AddScoped<IConfigService, ConfigService>();
    }

    private static void ConfigureOrchestratorServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicNotificationOrchestrator, TopicNotificationOrchestrator>();
    }
}
