namespace Boonkrua.Models.Dto;

public interface IDto<out TEntity>
{
    public TEntity ToEntity();
}
