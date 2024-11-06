namespace Boonkrua.Models.Request;

public record CreateTopicRequest(
    string Title,
    string? Description,
    List<CreateTopicRequest>? ChildTopics = null
);
