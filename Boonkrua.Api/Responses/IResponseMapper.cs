namespace Boonkrua.Api.Responses;

public interface IResponseMapper<out TResponse, in TDto>
{
    public static abstract TResponse FromDto(TDto dto);
}
