namespace Boonkrua.Models.Request.Topics;

public sealed record CreateTopicRequest(
    string Title,
    string? Description,
    List<CreateTopicRequest>? ChildTopics = null
);
