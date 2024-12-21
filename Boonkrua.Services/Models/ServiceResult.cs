using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Models;

public readonly struct ServiceResult<TContent>
{
    private readonly Result<TContent, AError> _result;

    private ServiceResult(TContent content)
    {
        _result = Result<TContent, AError>.Ok(content);
    }

    private ServiceResult(AError error)
    {
        _result = Result<TContent, AError>.Err(error);
    }

    public static implicit operator ServiceResult<TContent>(TContent content) => new(content);

    public static implicit operator ServiceResult<TContent>(AError error) => new(error);

    public TReturn Match<TReturn>(
        Func<TContent, TReturn> onSuccess,
        Func<AError, TReturn> onFailure
    ) => _result.Match(onSuccess, onFailure);

    public bool IsSuccessful => _result.IsSuccessful;
}
