namespace Boonkrua.Service.Interfaces.Mappers;

public interface IEntityMapper<in TEntity, out TDto>
{
    static abstract TDto FromEntity(TEntity entity);
}
