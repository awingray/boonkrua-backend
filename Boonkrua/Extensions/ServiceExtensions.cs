using Boonkrua.Factories;
using Boonkrua.Repositories.Topics;
using Boonkrua.Services.Notifications;
using Boonkrua.Services.Topics;
using Boonkrua.Services.Topics.Interfaces;
using MongoDB.Driver;

namespace Boonkrua.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMongoDb(this IServiceCollection services, string dbName)
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

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ITopicRepository, TopicRepository>();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITopicNotificationService, TopicNotificationService>();
    }

    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<DiscordNotificationService>(
            (sp, client) =>
            {
                client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Add("User-Agent", "Boonkrua-NotificationService");
            }
        );
    }

    public static void ConfigureFactories(this IServiceCollection services)
    {
        services.AddTransient<NotificationServiceFactory>();
    }
}
