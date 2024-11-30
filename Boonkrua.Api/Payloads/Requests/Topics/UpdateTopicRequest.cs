using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Payloads.Requests.Topics;

public sealed record UpdateTopicRequest : ATopicRequest, IRequestMapper<TopicDto, string>
{
    public required string Id { get; init; }
    public List<UpdateTopicRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto(string param) =>
        TopicDto.Create(
            Id,
            param,
            Title,
            ChildTopics?.ToMappedList(t => t.ToDto(param)) ?? [],
            Description
        );
}
