using Boonkrua.Data.Repositories.Topics;
using Boonkrua.Data.Repositories.Topics.Interfaces;
using Boonkrua.Service.Factories;
using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Notifications;
using Boonkrua.Service.Topics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace Boonkrua.Http.Extensions;

internal static class ServiceExtensions
{
    internal static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Boonkrua API", Version = "v1" });
            options.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "Enter 'Bearer' [space] and then your token in the text input below.\n\nExample: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...`",
                }
            );

            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        },
                        Array.Empty<string>()
                    },
                }
            );
        });
    }

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
