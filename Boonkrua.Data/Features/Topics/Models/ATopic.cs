using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Boonkrua.Data.Features.Topics.Models;

public abstract class ATopic
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; protected init; } = default!;

    [BsonElement("title")]
    public required string Title { get; init; }

    [BsonElement("description")]
    public string? Description { get; protected init; }
}
