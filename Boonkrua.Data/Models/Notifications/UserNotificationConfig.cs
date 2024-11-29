using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Boonkrua.Data.Models.Notifications;

public sealed class UserNotificationConfig
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private init; } = default!;

    [BsonElement("userId")]
    public required string UserId { get; init; }

    [BsonElement("vendors")]
    public Vendor[] Vendors { get; private init; } = [];

    private UserNotificationConfig() { }

    public static UserNotificationConfig Create(string userId, Vendor[]? vendors = null) =>
        new() { UserId = userId, Vendors = vendors ?? [] };
}
