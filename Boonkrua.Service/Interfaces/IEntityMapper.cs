namespace Boonkrua.Service.Interfaces;

public interface IEntityMapper<in TEntity, out TDto>
{
    static abstract TDto FromEntity(TEntity entity);
}