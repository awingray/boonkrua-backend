using Boonkrua.Service.Features.Notifications;
using Boonkrua.Service.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Topics;
using Boonkrua.Service.Features.Topics.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using INotificationService = Boonkrua.Service.Features.Topics.Interfaces.INotificationService;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IService, Service.Features.Topics.Service>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IConfigService, ConfigService>();
    }
}
