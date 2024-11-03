using Boonkrua.Extensions;
using Boonkrua.Handlers;
using Boonkrua.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMongoDb(
    builder.Configuration.GetSection("MongoDB").GetValue<string>("DatabaseName") ?? nameof(Boonkrua)
);
builder.Services.ConfigureRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/topic/{id:long}",
        async (long id, ITopicRetrievalRepository repository) =>
            await TopicHandler.GetTopicById(id, repository)
    )
    .WithName("GetTopicById")
    .WithOpenApi();

await app.RunAsync();
