using Boonkrua.Services.Features.Topics;
using Microsoft.Extensions.DependencyInjection;
using ConfigService = Boonkrua.Services.Features.Configs.Service;
using IConfigService = Boonkrua.Services.Features.Configs.Interfaces.IService;
using INotificationService = Boonkrua.Services.Features.Topics.Interfaces.INotificationService;
using ITopicService = Boonkrua.Services.Features.Topics.Interfaces.IService;
using TopicService = Boonkrua.Services.Features.Topics.Service;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IConfigService, ConfigService>();
    }
}
