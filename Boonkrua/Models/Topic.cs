using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Models;

public sealed record Topic : ATopic
{
    [BsonIgnoreIfNull]
    [BsonElement("parentTopic")]
    public Topic? ParentTopic { get; private init; }

    [JsonIgnore]
    [BsonElement("childTopics")]
    public List<Topic> ChildTopics { get; private init; } = [];

    private Topic() { }

    public static Topic CreateParent(ObjectId id, string title, string? description = null) =>
        new()
        {
            Id = id,
            Title = title,
            Description = description,
        };

    public static Topic CreateChild(
        ObjectId id,
        string title,
        Topic parentTopic,
        string? description = null
    ) =>
        new()
        {
            Id = id,
            Title = title,
            ParentTopic = parentTopic,
            Description = description,
        };
}
