using Boonkrua.Constants;

namespace Boonkrua.Models.Error;

public sealed record NotificationError : AError
{
    private NotificationError(string errorMessage)
        : base(errorMessage) { }

    public static NotificationError SendFailure => new(NotificationMessages.SendFailure);
    public static NotificationError InvalidType => new(NotificationMessages.InvalidProvider);
    public static NotificationError NoContent => new(NotificationMessages.NoContent);
}
