using Boonkrua.Services.Features.Configs;
using Boonkrua.Services.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Topics;
using Boonkrua.Services.Features.Topics.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using INotificationService = Boonkrua.Services.Features.Topics.Interfaces.INotificationService;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IConfigService, ConfigConfigService>();
    }
}
