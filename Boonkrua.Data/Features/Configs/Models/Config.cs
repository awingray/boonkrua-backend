using Boonkrua.Shared.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Boonkrua.Data.Features.Configs.Models;

public sealed class Config
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private init; } = null!;

    [BsonElement("userId")]
    public required string UserId { get; init; }

    [BsonElement("vendors")]
    public List<Vendor> Vendors { get; private init; } = [];

    private Config() { }

    public string? GetKeyByType(NotificationType type) => Vendors.Find(v => v.Type == type)?.Key;

    public static Config Create(string userId, List<Vendor>? vendors = null, string? id = null) =>
        new()
        {
            UserId = userId,
            Vendors = vendors ?? [],
            Id = id ?? null!,
        };
}
