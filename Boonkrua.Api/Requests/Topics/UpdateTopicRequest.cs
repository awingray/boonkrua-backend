using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto.Topics;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Requests.Topics;

public sealed record UpdateTopicRequest : IRequestMapper<TopicDto, string>
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public List<CreateTopicRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto(string param) =>
        TopicDto.Create(
            Id,
            param,
            Title,
            ChildTopics?.ToMappedList(t => t.ToDto(param)) ?? [],
            Description
        );
}
