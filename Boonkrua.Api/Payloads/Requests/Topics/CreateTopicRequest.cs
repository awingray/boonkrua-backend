using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Payloads.Requests.Topics;

public sealed record CreateTopicRequest : ATopicRequest, IRequestMapper<TopicDto, string>
{
    public List<CreateTopicRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto(string param) =>
        TopicDto.Create(
            Title,
            param,
            ChildTopics?.ToMappedList(t => t.ToDto(param)) ?? [],
            Description
        );
}
