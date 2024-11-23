namespace Boonkrua.Service.Models;

public sealed record NotificationPayload
{
    public required string Message { get; init; }

    public required string Key { get; init; }

    private NotificationPayload() { }

    public static NotificationPayload Create(string message, string key) =>
        new() { Message = message, Key = key };
}
