using Boonkrua.Services.Features.Notifications.Factories;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureFactories(this IServiceCollection services)
    {
        services.AddScoped<INotificationServiceFactory, NotificationServiceFactory>();
    }
}
