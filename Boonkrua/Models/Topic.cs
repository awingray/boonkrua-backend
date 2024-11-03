using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Models;

internal sealed record Topic : ATopic
{
    [BsonIgnoreIfNull]
    [BsonElement("parentTopic")]
    public Topic? ParentTopic { get; init; }

    [JsonIgnore]
    [BsonElement("childTopics")]
    public List<Topic> ChildTopics { get; init; } = [];

    private Topic() { }

    public static Topic CreateParent(long id, string title, string? description = null) =>
        new()
        {
            Id = id,
            Title = title,
            Description = description,
        };

    public static Topic CreateChild(
        long id,
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
