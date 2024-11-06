namespace Boonkrua.Models.Dto.Interfaces;

public interface IEntityMapper<out TDto>
{
    TDto ToDto();
}
