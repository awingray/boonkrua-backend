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

// [BsonKnownTypes(typeof(LineConfig), typeof(DiscordConfig))]
// public abstract class VendorConfig(NotificationType type)
// {
//     [BsonElement("type")]
//     [BsonRepresentation(BsonType.String)]
//     public NotificationType Type { get; init; } = type;
// }
//
// public sealed class LineConfig() : VendorConfig(NotificationType.Line)
// {
//     [BsonElement("userId")]
//     public string? UserId { get; init; }
// }
//
// public sealed class DiscordConfig() : VendorConfig(NotificationType.Discord)
// {
//     [BsonElement("webhookUrl")]
//     public string? WebhookUrl { get; init; }
// }
