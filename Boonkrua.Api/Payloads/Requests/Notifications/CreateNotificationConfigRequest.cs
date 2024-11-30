using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Payloads.Requests.Notifications;

public sealed record CreateNotificationConfigRequest : IRequestMapper<NotificationConfigDto>
{
    public required string UserId { get; init; }
    public List<VendorRequest> Vendors { get; init; } = [];
    
    public NotificationConfigDto ToDto() =>
        NotificationConfigDto.Create(UserId, Vendors.ToMappedList(v => v.ToDto()));
}


