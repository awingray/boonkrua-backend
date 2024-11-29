using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto.Topics;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Payload.Requests.Topics;

public sealed record CreateTopicRequest : IRequestMapper<TopicDto, string>
{
    public required string Title { get; init; }
    public string? Description { get; init; }
    public List<CreateTopicRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto(string param) =>
        TopicDto.Create(
            Title,
            param,
            ChildTopics?.ToMappedList(t => t.ToDto(param)) ?? [],
            Description
        );
}
