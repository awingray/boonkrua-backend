using Boonkrua.Api.Features.Topics.Requests;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Topics.Mappers;

public static class TopicRequestMapper
{
    public static TopicDto ToDto(this TopicCreateRequest request, string userId) =>
        TopicDto.Create(
            request.Title,
            userId,
            request.ChildTopics?.ToMappedList(t => t.ToDto(userId)) ?? [],
            request.Description
        );

    public static TopicDto ToDto(this TopicUpdateRequest request, string userId) =>
        TopicDto.Create(
            request.Id,
            userId,
            request.Title,
            request.ChildTopics?.ToMappedList(t => t.ToDto(userId)) ?? [],
            request.Description
        );
}
