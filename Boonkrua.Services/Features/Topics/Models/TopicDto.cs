namespace Boonkrua.Services.Features.Topics.Models;

public sealed record TopicDto
{
    public string? Id { get; private init; }
    public required string UserId { get; init; }
    public required string Title { get; init; }
    public List<TopicDto> ChildTopics { get; private init; } = [];
    public string? Description { get; private init; }

    private TopicDto() { }

    public static TopicDto Create(
        string title,
        string userId,
        List<TopicDto> childTopics,
        string? description
    ) =>
        new()
        {
            Title = title,
            UserId = userId,
            Description = description,
            ChildTopics = childTopics,
        };

    public static TopicDto Create(
        string id,
        string userId,
        string title,
        List<TopicDto> childTopics,
        string? description
    ) =>
        new()
        {
            Id = id,
            UserId = userId,
            Title = title,
            Description = description,
            ChildTopics = childTopics,
        };
}
