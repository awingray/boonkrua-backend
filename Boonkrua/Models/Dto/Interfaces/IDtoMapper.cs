namespace Boonkrua.Models.Dto.Interfaces;

public interface IDtoMapper<out TEntity>
{
    TEntity ToEntity();
}
