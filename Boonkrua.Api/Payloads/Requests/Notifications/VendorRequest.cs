using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Api.Payloads.Requests.Notifications;

public sealed record VendorRequest : IRequestMapper<VendorDto>
{
    public NotificationType Type { get; init; }
    public Dictionary<string, string> Config { get; init; } = [];
    
    public VendorDto ToDto() => 
        VendorDto.Create(Type,Config);
}