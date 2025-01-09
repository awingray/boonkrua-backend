namespace Boonkrua.Services.Features.Configs.Models;

public sealed record ConfigDto
{
    public string? Id { get; private init; }

    public required string UserId { get; init; }

    public List<VendorDto> Vendors { get; private init; } = [];

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
}
