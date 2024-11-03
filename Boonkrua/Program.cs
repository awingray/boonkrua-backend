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
app.MapTopicEndpoints();

await app.RunAsync();
