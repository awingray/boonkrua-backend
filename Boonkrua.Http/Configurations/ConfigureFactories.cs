using Boonkrua.Service.Factories;

namespace Boonkrua.Http.Configurations;

internal static partial class ServiceExtensions
{
    internal static void ConfigureFactories(this IServiceCollection services)
    {
        services.AddTransient<NotificationServiceFactory>();
    }
}
