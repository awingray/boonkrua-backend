using Boonkrua.Data.Features.Topics.Models;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Services.Features.Topics.Mappers;

public static class TopicDtoMapper
{
    public static Topic ToEntity(this TopicDto dto) =>
        Topic.Create(
            dto.Title,
            dto.UserId,
            dto.ChildTopics.ToMappedList(t => t.ToEntity()),
            dto.Description,
            dto.Id
        );

    public static TopicDto FromEntity(Topic entity) =>
        TopicDto.Create(
            entity.Id,
            entity.UserId,
            entity.Title,
            entity.ChildTopics.ToMappedList(FromEntity),
            entity.Description
        );
}
