namespace Boonkrua.Models.Request.Topics;

public sealed record UpdateTopicRequest(
    string Id,
    string Title,
    string? Description,
    List<CreateTopicRequest>? ChildTopics = null
);
