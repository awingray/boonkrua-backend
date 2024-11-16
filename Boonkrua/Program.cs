using Boonkrua.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

app.UseHttpsRedirection();
app.MapTopicEndpoints();

await app.RunAsync();
