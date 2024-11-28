namespace Boonkrua.Api.Interfaces;

internal interface IRequestMapper<out TDto>
{
    TDto ToDto();
}

internal interface IRequestMapper<out TDto, in TParam>
{
    TDto ToDto(TParam param);
}
