using Boonkrua.Data.Features.Configs.Models;
using Boonkrua.Services.Features.Configs.Models;

namespace Boonkrua.Services.Features.Configs.Mappers;

public static class VendorDtoMapper
{
    public static Vendor ToEntity(this VendorDto dto) => Vendor.Create(dto.Type, dto.Key);

    public static VendorDto FromEntity(Vendor entity) => VendorDto.Create(entity.Type, entity.Key);
}
