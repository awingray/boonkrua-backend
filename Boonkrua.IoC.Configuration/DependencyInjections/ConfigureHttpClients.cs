using Boonkrua.Services.Features.Notifications;
using Boonkrua.Services.Features.Notifications.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<DiscordService>();

        services.AddHttpClient<LineService>(
            (_, client) =>
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        JwtBearerDefaults.AuthenticationScheme,
                        Environment.GetEnvironmentVariable("LINE_ACCESS_TOKEN")
                    );
            }
        );
    }
}
