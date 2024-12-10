using Boonkrua.Api.Features.Notifications;
using Boonkrua.Api.Features.Topics;
using Boonkrua.IoC.Configuration.DependencyInjections;
using Boonkrua.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureKeycloak(builder.Configuration.GetSection("Keycloak"));
builder.Services.ConfigureMongoDb(
    builder.Configuration.GetSection("MongoDB").GetValue<string>("DatabaseName") ?? nameof(Boonkrua)
);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();
builder.Services.ConfigureFactories();
builder.Services.ConfigureHttpClients();

builder.Services.Configure<LineSettings>(builder.Configuration.GetSection("Vendor:LINE"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapTopicEndpoints();
app.MapNotificationConfigEndpoints();

await app.RunAsync();
