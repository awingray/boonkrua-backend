namespace Boonkrua.Models.Request;

public sealed record CreateTopicRequest(
    string Title,
    string? Description,
    List<CreateTopicRequest>? ChildTopics = null
);
