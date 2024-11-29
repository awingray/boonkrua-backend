using Boonkrua.Data.Models.Notifications;
using Boonkrua.Service.Models.Dto.Mappers;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Service.Models.Dto.Notification;

public sealed record VendorDto : IDtoMapper<Vendor>, IEntityMapper<Vendor, VendorDto>
{
    public NotificationType Type { get; private init; }

    public Dictionary<string, string> Config { get; private init; } = [];

    private VendorDto() { }

    public static VendorDto Create(NotificationType type, Dictionary<string, string> config) =>
        new() { Type = type, Config = config };

    public Vendor ToEntity() => Vendor.Create(Type, Config);

    public static VendorDto FromEntity(Vendor entity) => Create(entity.Type, entity.Config);
}
