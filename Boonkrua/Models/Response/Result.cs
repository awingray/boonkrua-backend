namespace Boonkrua.Models.Response;

public sealed record Result<T>
{
    public T? Data { get; init; }

    public string? Message { get; init; }

    private Result() { }

    public static Result<T> Create(T? data, string? message = null) =>
        new() { Data = data, Message = message };
}
