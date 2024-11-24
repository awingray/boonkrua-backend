using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Boonkrua.Http.Configurations;

internal static partial class ServiceExtensions
{
    internal static void ConfigureKeycloak(
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
