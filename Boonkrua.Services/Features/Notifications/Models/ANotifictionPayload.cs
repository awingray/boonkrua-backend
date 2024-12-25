namespace Boonkrua.Services.Features.Notifications.Models;

public abstract record NotificationPayloadBase
{
    public string Message { get; init; }
    public string Key { get; init; }

    protected NotificationPayloadBase(string message, string key)
    {
        Message = message;
        Key = key;
    }

    public abstract object ToServicePayload();
}
