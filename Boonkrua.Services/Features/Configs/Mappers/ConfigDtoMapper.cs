using Boonkrua.Data.Features.Configs.Models;
using Boonkrua.Services.Features.Configs.Models;

namespace Boonkrua.Services.Features.Configs.Mappers;

public static class ConfigDtoMapper
{
    public static ConfigDto FromEntity(Config entity) =>
        ConfigDto.Create(
            entity.UserId,
            entity.Vendors.ConvertAll(VendorDtoMapper.FromEntity),
            entity.Id
        );

    public static Config ToEntity(this ConfigDto dto) =>
        Config.Create(dto.UserId, dto.Vendors.ConvertAll(v => v.ToEntity()), dto.Id);
}
