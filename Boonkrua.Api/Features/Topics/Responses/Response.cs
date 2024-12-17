using Boonkrua.Api.Interfaces;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Topics.Responses;

public sealed record Response : IResponseMapper<Response, TopicDto>
{
    public string? Id { get; init; }
    public required string Title { get; init; }
    public List<Response> ChildTopics { get; init; } = [];
    public string? Description { get; init; }

    public static Response FromDto(TopicDto dto) =>
        new()
        {
            Id = dto.Id,
            Title = dto.Title,
            ChildTopics = dto.ChildTopics.ToMappedList(FromDto),
            Description = dto.Description,
        };
};
