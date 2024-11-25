using Boonkrua.Data.Models.Topics;
using Boonkrua.DataContracts.Request.Topics;
using Boonkrua.Service.Models.Dto.Mappers;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Service.Models.Dto.Topics;

public sealed record TopicDto
    : IDtoMapper<Topic>,
        IRequestMapper<CreateTopicRequest, TopicDto>,
        IRequestMapper<UpdateTopicRequest, TopicDto>,
        IEntityMapper<Topic, TopicDto>
{
    public string? Id { get; private init; }
    public required string Title { get; init; }
    public List<TopicDto> ChildTopics { get; private init; } = [];
    public string? Description { get; private init; }

    private TopicDto() { }

    public Topic ToEntity() =>
        Topic.Create(Title, ChildTopics.ToMappedList(t => t.ToEntity()), Description, Id);

    public static TopicDto FromRequest(CreateTopicRequest request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            ChildTopics = request.ChildTopics?.ToMappedList(FromRequest) ?? [],
        };

    public static TopicDto FromRequest(UpdateTopicRequest request) =>
        new()
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            ChildTopics = request.ChildTopics?.ToMappedList(FromRequest) ?? [],
        };

    public static TopicDto FromEntity(Topic entity) =>
        new()
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
        };
}
