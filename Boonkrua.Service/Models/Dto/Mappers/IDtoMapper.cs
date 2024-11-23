namespace Boonkrua.Service.Models.Dto.Mappers;

public interface IDtoMapper<out TEntity>
{
    TEntity ToEntity();
}
