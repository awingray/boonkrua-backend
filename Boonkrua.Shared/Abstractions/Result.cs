namespace Boonkrua.Shared.Abstractions;

public class Result<TResult, TError>
{
    private readonly bool _success;
    public TResult? Content { get; }
    public TError? Error { get; }
    public bool IsSuccessful => _success;

    private Result(TResult? result, TError? error, bool success)
    {
        Content = result;
        Error = error;
        _success = success;
    }

    public static Result<TResult, TError> Ok(TResult result) => new(result, default, true);

    public static Result<TResult, TError> Err(TError error) => new(default, error, false);

    public static implicit operator Result<TResult, TError>(TResult result) => Ok(result);

    public static implicit operator Result<TResult, TError>(TError error) => Err(error);

    public TReturn Match<TReturn>(Func<TResult, TReturn> success, Func<TError, TReturn> failure) =>
        _success ? success(Content!) : failure(Error!);
}
