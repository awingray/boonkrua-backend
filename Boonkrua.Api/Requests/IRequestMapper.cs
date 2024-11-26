namespace Boonkrua.Api.Requests;

public interface IRequestMapper<out TDto>
{
    TDto ToDto();
}

public interface IRequestMapper<out TDto, in TParam>
{
    TDto ToDto(TParam param);
}
