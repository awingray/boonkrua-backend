using Boonkrua.Api.Features.Topics.Responses;
using Boonkrua.Services.Features.Topics.Models;

namespace Boonkrua.Api.Features.Topics.Mappers;

public static class TopicResponseMapper
{
    public static TopicResponse FromDto(TopicDto dto) =>
        new(dto.Id, dto.Title, dto.ChildTopics.ConvertAll(FromDto), dto.Description);
}
