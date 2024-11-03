using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Models.Data;

public sealed class Topic : ATopic
{
    [BsonIgnoreIfNull]
    [BsonElement("parentTopic")]
    public Topic? ParentTopic { get; private set; }

    [BsonElement("childTopics")]
    public List<Topic> ChildTopics { get; private set; } = [];

    private Topic() { }

    public static Topic CreateParent(
        string title,
        List<Topic>? childTopics = null,
        string? description = null
    ) =>
        new()
        {
            Title = title,
            Description = description,
            ChildTopics = childTopics ?? [],
        };

    public static Topic CreateChild(
        string title,
        Topic parentTopic,
        List<Topic>? childTopics = null,
        string? description = null
    ) =>
        new()
        {
            Title = title,
            ParentTopic = parentTopic,
            ChildTopics = childTopics ?? [],
            Description = description,
        };
}
