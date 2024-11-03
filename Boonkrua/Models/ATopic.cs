using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Models;

internal abstract record ATopic
{
    [BsonId]
    [BsonRepresentation(BsonType.Int64)]
    public required long Id { get; init; }

    [BsonElement("title")]
    public required string Title { get; init; }

    [BsonElement("description")]
    public string? Description { get; init; }
}
