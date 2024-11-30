namespace Boonkrua.Api.Payloads.Requests.Topics;

public record ATopicRequest
{
    public required string Title { get; init; }
    public string? Description { get; init; }
}