using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Http.Models.Data.Topics;

public sealed class Topic : ATopic
{
    [BsonElement("childTopics")]
    public List<Topic> ChildTopics { get; private set; } = [];

    private Topic() { }

    public static Topic Create(
        string title,
        List<Topic>? childTopics = null,
        string? description = null,
        string? id = null
    ) =>
        new()
        {
            Title = title,
            Description = description,
            ChildTopics = childTopics ?? [],
            Id = id ?? default!,
        };
}
