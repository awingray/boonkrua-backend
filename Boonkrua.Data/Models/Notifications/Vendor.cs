using Boonkrua.Shared.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Data.Models.Notifications;

public sealed class Vendor
{
    [BsonElement("type")]
    [BsonRepresentation(BsonType.String)]
    public NotificationType Type { get; private init; }

    [BsonElement("config")]
    public Dictionary<string, string> Config { get; private init; } = [];

    private Vendor() { }

    public static Vendor Create(NotificationType type, Dictionary<string, string>? config = null) =>
        new() { Type = type, Config = config ?? [] };
}
