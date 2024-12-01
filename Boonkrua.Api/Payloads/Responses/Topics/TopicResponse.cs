using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Payload.Responses.Topics;

public sealed record TopicResponse : IResponseMapper<TopicResponse, TopicDto>
{
    public string? Id { get; init; }
    public required string Title { get; init; }
    public List<TopicResponse> ChildTopics { get; init; } = [];
    public string? Description { get; init; }

    public static TopicResponse FromDto(TopicDto dto) =>
        new()
        {
            Id = dto.Id,
            Title = dto.Title,
            ChildTopics = dto.ChildTopics.ToMappedList(FromDto),
            Description = dto.Description,
        };
};
