namespace Boonkrua.Api.Features.Topics.Responses;

public sealed record TopicResponse(
    string? Id,
    string Title,
    List<TopicResponse> ChildTopics,
    string? Description
);
