using Boonkrua.Repositories;
using Boonkrua.Repositories.Topics;
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
}
