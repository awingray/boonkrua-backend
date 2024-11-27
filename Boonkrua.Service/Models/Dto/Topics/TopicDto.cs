using System.Text.Json.Serialization;
using Boonkrua.Data.Models.Topics;
using Boonkrua.Service.Models.Dto.Mappers;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Service.Models.Dto.Topics;

public sealed record TopicDto : IDtoMapper<Topic>, IEntityMapper<Topic, TopicDto>
{
    public string? Id { get; private init; }
    public required string UserId { get; init; }
    public required string Title { get; init; }
    public List<TopicDto> ChildTopics { get; private init; } = [];
    public string? Description { get; private init; }

    private TopicDto() { }

    public static TopicDto Create(
        string title,
        string userId,
        List<TopicDto> childTopics,
        string? description
    ) =>
        new()
        {
            Title = title,
            UserId = userId,
            Description = description,
            ChildTopics = childTopics,
        };

    public static TopicDto Create(
        string id,
        string userId,
        string title,
        List<TopicDto> childTopics,
        string? description
    ) =>
        new()
        {
            Id = id,
            UserId = userId,
            Title = title,
            Description = description,
            ChildTopics = childTopics,
        };

    public Topic ToEntity() =>
        Topic.Create(Title, UserId, ChildTopics.ToMappedList(t => t.ToEntity()), Description, Id);

    public static TopicDto FromEntity(Topic entity) =>
        new()
        {
            Id = entity.Id,
            UserId = entity.UserId,
            Title = entity.Title,
            ChildTopics = entity.ChildTopics.ToMappedList(FromEntity),
            Description = entity.Description,
        };
}
