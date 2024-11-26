using Boonkrua.Service.Models.Dto.Topics;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Requests.Topics;

public sealed record CreateTopicRequest : IRequestMapper<TopicDto>
{
    public required string Title { get; init; }
    public string? Description { get; init; }
    public List<CreateTopicRequest>? ChildTopics { get; init; } = null;

    public TopicDto ToDto() =>
        TopicDto.Create(Title, "", ChildTopics?.ToMappedList(t => t.ToDto()) ?? [], Description);
}
