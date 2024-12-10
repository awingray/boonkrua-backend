using MongoDB.Bson.Serialization.Attributes;

namespace Boonkrua.Data.Features.Topics.Models;

public sealed class Topic : ATopic
{
    [BsonElement("childTopics")]
    public List<Topic> ChildTopics { get; private init; } = [];

    [BsonElement("userId")]
    public required string UserId { get; init; }

    private Topic() { }

    public static Topic Create(
        string title,
        string userId,
        List<Topic>? childTopics = null,
        string? description = null,
        string? id = null
    ) =>
        new()
        {
            Title = title,
            UserId = userId,
            Description = description,
            ChildTopics = childTopics ?? [],
            Id = id ?? default!,
        };
}
