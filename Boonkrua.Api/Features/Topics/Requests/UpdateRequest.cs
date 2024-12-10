using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Topics.Requests;

public sealed record UpdateRequest : ARequest, IRequestMapper<TopicDto, string>
{
    public required string Id { get; init; }
    public List<UpdateRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto(string param) =>
        TopicDto.Create(
            Id,
            param,
            Title,
            ChildTopics?.ToMappedList(t => t.ToDto(param)) ?? [],
            Description
        );
}
