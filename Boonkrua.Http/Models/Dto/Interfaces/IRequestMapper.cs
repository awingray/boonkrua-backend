namespace Boonkrua.Http.Models.Dto.Interfaces;

public interface IRequestMapper<in TRequest, out TDto>
{
    static abstract TDto FromRequest(TRequest request);
}
