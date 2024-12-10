using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Api.Payloads.Requests.Notifications;

public sealed record VendorRequest : IRequestMapper<VendorDto>
{
    public required string Type { get; init; }
    public Dictionary<string, string> Config { get; init; } = [];

    public VendorDto ToDto()
    {
        if (!Type.TryParse(out NotificationType type))
        {
            throw new InvalidOperationException(NotificationConfigMessages.InvalidNotificationType);
        }

        return VendorDto.Create(type, Config);
    }
}
