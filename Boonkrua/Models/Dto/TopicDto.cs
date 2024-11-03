using Boonkrua.Extensions;
using Boonkrua.Models.Data;

namespace Boonkrua.Models.Dto;

public record TopicDto : IDto<Topic>
{
    public required string Title { get; init; }
    public List<TopicDto> ChildTopics { get; init; } = [];
    public string? Description { get; init; }

    public Topic ToEntity() =>
        Topic.Create(Title, ChildTopics.ToMappedList(t => t.ToEntity()), Description);
}
