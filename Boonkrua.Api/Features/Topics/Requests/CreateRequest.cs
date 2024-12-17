using Boonkrua.Api.Interfaces;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Topics.Requests;

public sealed record CreateRequest : ARequest, IRequestMapper<TopicDto, string>
{
    public List<CreateRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto(string param) =>
        TopicDto.Create(
            Title,
            param,
            ChildTopics?.ToMappedList(t => t.ToDto(param)) ?? [],
            Description
        );
}
