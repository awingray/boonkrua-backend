using Boonkrua.Common.Messages;

namespace Boonkrua.Models.Error.Notifications;

public sealed record NotificationError : AError
{
    private NotificationError(string errorMessage)
        : base(errorMessage) { }

    public static NotificationError SendFailure => new(NotificationMessages.SendFailure);
}
