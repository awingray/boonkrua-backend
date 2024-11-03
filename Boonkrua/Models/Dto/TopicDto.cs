using Boonkrua.Models.Data;

namespace Boonkrua.Models.Dto;

public sealed record ParentTopicDto(
    string Title,
    List<Topic>? ChildTopics = null,
    string? Description = null
);
