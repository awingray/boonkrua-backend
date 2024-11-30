using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Payloads.Requests.Notifications;

public sealed record CreateNotificationConfigRequest : IRequestMapper<NotificationConfigDto, string>
{
    public List<VendorRequest> Vendors { get; init; } = [];

    public NotificationConfigDto ToDto(string param) =>
        NotificationConfigDto.Create(param, Vendors.ToMappedList(v => v.ToDto()));
}
