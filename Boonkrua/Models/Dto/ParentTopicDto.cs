using Boonkrua.Extensions;
using Boonkrua.Models.Data;

namespace Boonkrua.Models.Dto;

public abstract record ParentTopicDto : IDto<Topic>
{
    public required string Title { get; init; }

    protected List<ChildTopicDto> ChildTopics { get; init; } = [];
    public string? Description { get; init; }

    public Topic ToEntity() =>
        Topic.CreateParent(Title, ChildTopics.ToMappedList(t => t.ToEntity()), Description);
}
