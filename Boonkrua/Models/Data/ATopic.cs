using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Models.Data;

public abstract class ATopic
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; } = ObjectId.GenerateNewId();

    [BsonElement("title")]
    public required string Title { get; init; }

    [BsonElement("description")]
    public string? Description { get; protected init; }
}
