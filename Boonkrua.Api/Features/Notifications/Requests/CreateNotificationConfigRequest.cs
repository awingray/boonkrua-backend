using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Notifications.Requests;

public sealed record CreateNotificationConfigRequest : IRequestMapper<NotificationConfigDto, string>
{
    public List<VendorRequest> Vendors { get; init; } = [];

    public NotificationConfigDto ToDto(string param) =>
        NotificationConfigDto.Create(param, Vendors.ToMappedList(v => v.ToDto()));
}
