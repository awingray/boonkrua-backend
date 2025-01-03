using Boonkrua.Data.Features.Configs.Models;
using Boonkrua.Services.Interfaces;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Configs.Models;

public sealed record VendorDto : IDtoMapper<Vendor>, IEntityMapper<Vendor, VendorDto>
{
    public NotificationType Type { get; private init; }

    public required string Key { get; init; }

    private VendorDto() { }

    public static VendorDto Create(NotificationType type, string key) =>
        new() { Type = type, Key = key };

    public Vendor ToEntity() => Vendor.Create(Type, Key);

    public static VendorDto FromEntity(Vendor entity) => Create(entity.Type, entity.Key);
}
