using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Configs.Models;

public sealed record VendorDto
{
    public NotificationType Type { get; private init; }

    public required string Key { get; init; }

    private VendorDto() { }

    public static VendorDto Create(NotificationType type, string key) =>
        new() { Type = type, Key = key };
}
