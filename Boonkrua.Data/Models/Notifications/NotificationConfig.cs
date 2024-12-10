using Boonkrua.Shared.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Boonkrua.Data.Models.Notifications;

public sealed class NotificationConfig
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private init; } = default!;

    // TODO: make sure there is one unique config for each user.
    [BsonElement("userId")]
    public required string UserId { get; init; }

    [BsonElement("vendors")]
    public List<Vendor> Vendors { get; private init; } = [];

    private NotificationConfig() { }

    public Vendor? GetVendorByType(NotificationType type) => Vendors.Find(v => v.Type == type);

    public static NotificationConfig Create(
        string userId,
        List<Vendor>? vendors = null,
        string? id = null
    ) =>
        new()
        {
            UserId = userId,
            Vendors = vendors ?? [],
            Id = id ?? default!,
        };
}
