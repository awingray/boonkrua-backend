using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Models;

public abstract record ATopic
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required ObjectId Id { get; init; } = ObjectId.GenerateNewId();

    [BsonElement("title")]
    public required string Title { get; init; }

    [BsonElement("description")]
    public string? Description { get; protected init; }
}
