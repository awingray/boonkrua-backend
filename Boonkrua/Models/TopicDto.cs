namespace Boonkrua.Models;

public sealed record ParentTopicDto(
    string Title,
    List<Topic>? ChildTopics = null,
    string? Description = null
);
