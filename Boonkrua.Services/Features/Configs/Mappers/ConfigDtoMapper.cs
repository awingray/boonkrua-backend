using Boonkrua.Data.Features.Configs.Models;
using Boonkrua.Services.Features.Configs.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Services.Features.Configs.Mappers;

public static class ConfigDtoMapper
{
    public static ConfigDto FromEntity(Config entity) =>
        ConfigDto.Create(
            entity.UserId,
            entity.Vendors.ToMappedList(VendorDtoMapper.FromEntity),
            entity.Id
        );

    public static Config ToEntity(this ConfigDto dto) =>
        Config.Create(dto.UserId, dto.Vendors.ToMappedList(v => v.ToEntity()), dto.Id);
}
