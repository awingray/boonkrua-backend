namespace Boonkrua.Http.Models.Response;

public sealed record MessageResponse
{
    public string Message { get; }

    private MessageResponse(string message) => Message = message;

    public static MessageResponse Create(string message) => new(message);
}
