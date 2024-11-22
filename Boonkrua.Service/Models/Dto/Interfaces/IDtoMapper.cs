namespace Boonkrua.Service.Models.Dto.Interfaces;

public interface IDtoMapper<out TEntity>
{
    TEntity ToEntity();
}
