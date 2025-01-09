using Boonkrua.Api.Features.Configs.Requests;
using Boonkrua.Services.Features.Configs.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Configs.Mappers;

public static class ConfigCreateRequestMapper
{
    public static ConfigDto ToDto(this ConfigCreateRequest request, string param) =>
        ConfigDto.Create(param, request.Vendors.ToMappedList(v => v.ToDto()));
}
