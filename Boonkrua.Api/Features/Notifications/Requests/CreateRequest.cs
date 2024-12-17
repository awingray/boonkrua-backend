using Boonkrua.Api.Interfaces;
using Boonkrua.Service.Features.Configs.Models;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Notifications.Requests;

public sealed record CreateRequest : IRequestMapper<ConfigDto, string>
{
    public List<VendorRequest> Vendors { get; init; } = [];

    public ConfigDto ToDto(string param) =>
        ConfigDto.Create(param, Vendors.ToMappedList(v => v.ToDto()));
}
