namespace Boonkrua.Models.Response;

public readonly struct Result<TResult, TError>
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

    public static implicit operator Result<TResult, TError>(TResult result) =>
        new(result, default, true);

    public static implicit operator Result<TResult, TError>(TError error) =>
        new(default, error, false);
}
