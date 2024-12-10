namespace Boonkrua.Api.Features.Topics.Requests;

public record ATopicRequest
{
    public required string Title { get; init; }
    public string? Description { get; init; }
}
