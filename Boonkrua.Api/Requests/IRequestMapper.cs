namespace Boonkrua.Api.Requests;

public interface IRequestMapper<out TDto>
{
    TDto ToDto();
}
