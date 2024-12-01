namespace Boonkrua.Api.Interfaces;

internal interface IResponseMapper<out TResponse, in TDto>
{
    internal static abstract TResponse FromDto(TDto dto);
}
