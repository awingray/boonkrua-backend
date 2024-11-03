using Boonkrua.Handlers;
using Boonkrua.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoClient>(
    new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"))
);
builder.Services.AddSingleton(c =>
{
    var client =
        c.GetService<IMongoClient>() ?? throw new InvalidOperationException("MongoClient is null");
    return client.GetDatabase(
        builder.Configuration.GetSection("MongoDB").GetValue<string>("DatabaseName")
    );
});
builder.Services.AddSingleton<ITopicRepository, TopicRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/topic/{id:long}",
        async (long id, ITopicRepository repository) => await repository.GetTopicById(id)
    )
    .WithName("GetTopicById")
    .WithOpenApi();

await app.RunAsync();
