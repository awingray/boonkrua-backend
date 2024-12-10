using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Api.Payloads.Requests.Notifications;

public sealed record VendorRequest : IRequestMapper<VendorDto>
{
    public required string Type { get; init; }
    public required string Key { get; init; }

    public VendorDto ToDto()
    {
        if (!Type.TryParse(out NotificationType type))
        {
            throw new InvalidOperationException(
                NotificationConfigMessages.Invalid.NotificationType
            );
        }

        return VendorDto.Create(type, Key);
    }
}
