using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Data.Models.Notifications;

public sealed class UserNotificationConfig
{
    [BsonElement("userId")]
    public required string UserId { get; init; }

    [BsonElement("vendors")]
    public Vendor[] Vendors { get; private init; } = [];

    private UserNotificationConfig() { }

    public static UserNotificationConfig Create(string userId, Vendor[]? vendors = null) =>
        new() { UserId = userId, Vendors = vendors ?? [] };
}
