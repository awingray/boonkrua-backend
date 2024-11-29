using Boonkrua.Service.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<DiscordNotificationService>(
            (_, client) =>
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Boonkrua-NotificationService");
            }
        );

        services.AddHttpClient<LineNotificationService>((_, client) => { });
    }
}
