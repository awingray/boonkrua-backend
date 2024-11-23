using Boonkrua.Data.Repositories.Topics;
using Boonkrua.Data.Repositories.Topics.Interfaces;
using Boonkrua.Service.Factories;
using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Notifications;
using Boonkrua.Service.Topics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MongoDB.Driver;

namespace Boonkrua.Http.Extensions;

internal static class ServiceExtensions
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
    }

    internal static void ConfigureMongoDb(this IServiceCollection services, string dbName)
    {
        services.AddSingleton<IMongoClient>(
            new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"))
        );
        services.AddSingleton(c =>
        {
            var client =
                c.GetService<IMongoClient>()
                ?? throw new InvalidOperationException("MongoClient is null");
            return client.GetDatabase(dbName);
        });
    }

    internal static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ITopicRepository, TopicRepository>();
    }

    internal static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITopicNotificationService, TopicNotificationService>();
    }

    internal static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<DiscordNotificationService>(
            (_, client) =>
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Boonkrua-NotificationService");
            }
        );
    }

    internal static void ConfigureFactories(this IServiceCollection services)
    {
        services.AddTransient<NotificationServiceFactory>();
    }
}
