using Boonkrua.Api.Interfaces;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Topics.Requests;

public sealed record TopicUpdateRequest : ATopicRequest, IRequestMapper<TopicDto, string>
{
    public required string Id { get; init; }
    public List<TopicUpdateRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto(string param) =>
        TopicDto.Create(
            Id,
            param,
            Title,
            ChildTopics?.ToMappedList(t => t.ToDto(param)) ?? [],
            Description
        );
}
