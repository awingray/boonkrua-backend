using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureKeycloak(
        this IServiceCollection services,
        IConfigurationSection config
    )
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = config.GetValue<string>("Authority");
                options.Audience = config.GetValue<string>("Audience");
                options.RequireHttpsMetadata = false;
            });
        services.AddAuthorization();
    }
}
