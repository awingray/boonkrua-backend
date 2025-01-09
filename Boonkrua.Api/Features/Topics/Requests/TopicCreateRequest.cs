namespace Boonkrua.Api.Features.Topics.Requests;

public sealed record TopicCreateRequest(List<TopicCreateRequest>? ChildTopics = null)
    : ATopicRequest;
