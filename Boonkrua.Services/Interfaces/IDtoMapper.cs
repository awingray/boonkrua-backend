namespace Boonkrua.Services.Interfaces;

public interface IDtoMapper<out TEntity>
{
    TEntity ToEntity();
}
