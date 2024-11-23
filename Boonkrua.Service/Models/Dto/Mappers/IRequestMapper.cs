namespace Boonkrua.Service.Models.Dto.Mappers;

public interface IRequestMapper<in TRequest, out TDto>
{
    static abstract TDto FromRequest(TRequest request);
}
