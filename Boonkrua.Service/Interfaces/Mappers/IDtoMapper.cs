namespace Boonkrua.Service.Interfaces.Mappers;

public interface IDtoMapper<out TEntity>
{
    TEntity ToEntity();
}
