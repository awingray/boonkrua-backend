namespace Boonkrua.Services.Features.Notifications.Models;

public sealed class NotificationPayload
{
    public required string Message { get; init; }

    public required string Key { get; init; }

    private NotificationPayload() { }

    public static NotificationPayload Create(string message, string key) =>
        new() { Message = message, Key = key };

    public DiscordPayload ToDiscordPayload() => new(Message);

    public LinePayload ToLinePayload() =>
        new(Key, [new LineMessage(nameof(LineMessageType.Text).ToLower(), Message)]);
}
