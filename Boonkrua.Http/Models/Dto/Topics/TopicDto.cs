using Boonkrua.Http.Extensions;
using Boonkrua.Http.Models.Data.Topics;
using Boonkrua.Http.Models.Dto.Interfaces;
using Boonkrua.Http.Models.Request.Topics;

namespace Boonkrua.Http.Models.Dto.Topics;

public sealed record TopicDto
    : IDtoMapper<Topic>,
        IRequestMapper<CreateTopicRequest, TopicDto>,
        IRequestMapper<UpdateTopicRequest, TopicDto>,
        IEntityMapper<Topic, TopicDto>
{
    public string? Id { get; private init; }
    public required string Title { get; init; }
    public List<TopicDto> ChildTopics { get; init; } = [];
    public string? Description { get; init; }

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
