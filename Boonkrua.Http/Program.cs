using Boonkrua.Http.Endpoints;
using Boonkrua.Http.Extensions;

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapTopicEndpoints();

await app.RunAsync();
