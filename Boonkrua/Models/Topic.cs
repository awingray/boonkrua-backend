namespace Boonkrua.Models;

public sealed record Topic
{
    public required long Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }

    public long? ParentTopicId { get; init; }
    public List<Topic> SubTopics { get; init; } = [];
}