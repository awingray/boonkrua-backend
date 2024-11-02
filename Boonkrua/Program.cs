using Boonkrua.Extensions;
using Boonkrua.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/topic/{id:long}",
        (long id) =>
        {
            Console.WriteLine(Topic.CreateParent(1, "Test").ToJson());
        }
    )
    .WithName("GetTopicById")
    .WithOpenApi();

await app.RunAsync();
