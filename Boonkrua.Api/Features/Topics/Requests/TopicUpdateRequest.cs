namespace Boonkrua.Api.Features.Topics.Requests;

public sealed record TopicUpdateRequest(string Id, List<TopicUpdateRequest>? ChildTopics = null)
    : ATopicRequest;
