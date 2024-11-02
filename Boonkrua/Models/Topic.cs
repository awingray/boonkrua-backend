using System.Text.Json.Serialization;

namespace Boonkrua.Models;

public abstract record ATopic
{
    public required long Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
}

public sealed record Topic : ATopic
{
    public Topic? ParentTopic { get; init; }

    [JsonIgnore]
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
