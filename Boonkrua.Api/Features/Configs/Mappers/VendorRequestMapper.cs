using Boonkrua.Api.Features.Configs.Requests;
using Boonkrua.Services.Features.Configs.Messages;
using Boonkrua.Services.Features.Configs.Models;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Configs.Mappers;

public static class VendorRequestMapper
{
    public static VendorDto ToDto(this VendorRequest request)
    {
        if (!request.Type.TryParse(out NotificationType type))
        {
            throw new InvalidOperationException(ConfigMessages.Invalid.NotificationType);
        }

        return VendorDto.Create(type, request.Key);
    }
}
