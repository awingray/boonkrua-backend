namespace Boonkrua.Api.Interfaces;

internal interface IResponseMapper<out TResponse, in TDto>
{
    public static abstract TResponse FromDto(TDto dto);
}
