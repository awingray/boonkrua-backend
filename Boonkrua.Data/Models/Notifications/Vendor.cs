using Boonkrua.Shared.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Data.Models.Notifications;

public sealed class Vendor
{
    [BsonElement("type")]
    [BsonRepresentation(BsonType.String)]
    public NotificationType Type { get; private init; }

    [BsonElement("key")]
    public required string Key { get; init; }

    private Vendor() { }

    public static Vendor Create(NotificationType type, string key) =>
        new() { Type = type, Key = key };
}
