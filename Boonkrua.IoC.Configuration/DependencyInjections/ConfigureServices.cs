using Boonkrua.Service.Interfaces.Notifications;
using Boonkrua.Service.Interfaces.Topics;
using Boonkrua.Service.Notifications;
using Boonkrua.Service.Topics;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITopicNotificationService, TopicNotificationService>();
        services.AddScoped<INotificationConfigService, NotificationConfigService>();
    }
}
