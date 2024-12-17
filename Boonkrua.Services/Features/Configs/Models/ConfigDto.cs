using Boonkrua.Data.Features.Configs.Models;
using Boonkrua.Services.Interfaces;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Services.Features.Configs.Models;

public sealed record ConfigDto : IEntityMapper<Config, ConfigDto>, IDtoMapper<Config>
{
    public string? Id { get; init; }

    public required string UserId { get; init; }

    public List<VendorDto> Vendors { get; init; } = [];

    private ConfigDto() { }

    public static ConfigDto Create(
        string userId,
        List<VendorDto>? vendors = null,
        string? id = null
    ) =>
        new()
        {
            UserId = userId,
            Vendors = vendors ?? [],
            Id = id,
        };

    public static ConfigDto FromEntity(Config entity) =>
        Create(entity.UserId, entity.Vendors.ToMappedList(VendorDto.FromEntity), entity.Id);

    public Config ToEntity() => Config.Create(UserId, Vendors.ToMappedList(v => v.ToEntity()), Id);
}
