using Boonkrua.Service.Features.Topics;
using Microsoft.Extensions.DependencyInjection;
using ConfigService = Boonkrua.Service.Features.Configs.Service;
using IConfigService = Boonkrua.Service.Features.Configs.Interfaces.IService;
using INotificationService = Boonkrua.Service.Features.Topics.Interfaces.INotificationService;
using ITopicService = Boonkrua.Service.Features.Topics.Interfaces;
using TopicService = Boonkrua.Service.Features.Topics.Service;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService.IService, TopicService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IConfigService, ConfigService>();
    }
}
