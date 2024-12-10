namespace Boonkrua.Service.Interfaces;

public interface IDtoMapper<out TEntity>
{
    TEntity ToEntity();
}
