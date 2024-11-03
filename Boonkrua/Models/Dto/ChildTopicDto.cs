using Boonkrua.Extensions;
using Boonkrua.Models.Data;

namespace Boonkrua.Models.Dto;

public abstract record ChildTopicDto : ParentTopicDto, IDto<Topic>
{
    public required ParentTopicDto ParentTopic { get; init; }

    public new Topic ToEntity() =>
        Topic.CreateChild(
            Title,
            ParentTopic.ToEntity(),
            ChildTopics.ToMappedList(t => t.ToEntity()),
            Description
        );
}
