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

    public static Topic CreateParent(string title, string? description = null) =>
        new() { Title = title, Description = description };

    public static Topic CreateChild(string title, Topic parentTopic, string? description = null) =>
        new()
        {
            Title = title,
            ParentTopic = parentTopic,
            Description = description,
        };
}
