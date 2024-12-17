using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Features.Configs.Models;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Api.Features.Notifications.Requests;

public sealed record VendorRequest : IRequestMapper<VendorDto>
{
    public required string Type { get; init; }
    public required string Key { get; init; }

    public VendorDto ToDto()
    {
        if (!Type.TryParse(out NotificationType type))
        {
            throw new InvalidOperationException(ConfigMessages.Invalid.NotificationType);
        }

        return VendorDto.Create(type, Key);
    }
}
