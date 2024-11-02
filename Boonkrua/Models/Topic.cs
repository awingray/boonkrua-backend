namespace Boonkrua.Models;

public abstract record ATopic
{
    public required long Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
}

public sealed record Topic : ATopic
{
    public Topic? RootTopic { get; init; }
    public List<Topic> ChildTopics { get; init; } = [];

    private Topic() { }

    public static Topic CreateRoot(long id, string title, string? description = null) =>
        new()
        {
            Id = id,
            Title = title,
            Description = description
        };

    public static Topic CreateChild(long id, string title, Topic parentTopic, string? description = null) =>
        new()
        {
            Id = id,
            Title = title,
            RootTopic = parentTopic,
            Description = description
        };
}